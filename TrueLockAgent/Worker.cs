
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TrueLockAgent
{
    public class Worker(ILogger<Worker> logger) : BackgroundService
    {
        private string[] blockedProcesses = Array.Empty<string>();
        private readonly object rulesLock = new();

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            logger.LogInformation("TrueLockAgent iniciado.");

            string filePath = Path.Combine(
                AppContext.BaseDirectory,
                "blocked-apps.json");

            logger.LogInformation(
    "Carpeta de configuración vigilada: {Directory}",
    AppContext.BaseDirectory);

            LoadBlockedProcesses(filePath);


            string configDirectory = Path.GetDirectoryName(filePath)!;

            using var fileWatcher = new FileSystemWatcher(configDirectory)
            {
                Filter = "*.json",
                NotifyFilter = NotifyFilters.LastWrite
                    | NotifyFilters.Size
                    | NotifyFilters.FileName
                    | NotifyFilters.CreationTime
            };

            fileWatcher.Changed += (_, args) =>
            {
                if (IsConfigFile(args.Name))
                    ReloadBlockedProcesses(filePath);
            };

            fileWatcher.Created += (_, args) =>
            {
                if (IsConfigFile(args.Name))
                    ReloadBlockedProcesses(filePath);
            };

            fileWatcher.Renamed += (_, args) =>
            {
                if (IsConfigFile(args.Name))
                    ReloadBlockedProcesses(filePath);
            };

            fileWatcher.EnableRaisingEvents = true;


            using var processWatcher = new ManagementEventWatcher(
                new WqlEventQuery(
                    "SELECT * FROM Win32_ProcessStartTrace"));

            processWatcher.EventArrived += (_, args) =>
            {
                var processName = args.NewEvent
                    .Properties["ProcessName"]?.Value?.ToString();

                var processIdValue = args.NewEvent
                    .Properties["ProcessID"]?.Value;

                if (string.IsNullOrWhiteSpace(processName) ||
                    processIdValue is null)
                {
                    return;
                }

                logger.LogInformation(
                    "Proceso detectado: {ProcessName}, PID: {ProcessId}",
                    processName,
                    processIdValue);

                try
                {
                    int processId = Convert.ToInt32(processIdValue);

                    using var detectedProcess =
                        Process.GetProcessById(processId);

                    string executablePath = detectedProcess.MainModule?.FileName
                        ?? "Ruta no disponible";

                    logger.LogInformation(
                        "Ruta detectada: {ExecutablePath}",
                        executablePath);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    logger.LogWarning(
                        "Windows no permitió consultar la ruta de {ProcessName}.",
                        processName);
                }
                catch (InvalidOperationException)
                {
                    logger.LogInformation(
                        "El proceso terminó antes de consultar su ruta.");
                }
                catch (ArgumentException)
                {
                    logger.LogInformation(
                        "El proceso ya no existe.");
                }

                bool isBlocked;

                lock (rulesLock)
                {
                    isBlocked = blockedProcesses.Any(
                        name => string.Equals(
                            name,
                            processName,
                            StringComparison.OrdinalIgnoreCase));
                }

                if (!isBlocked)
                    return;

                try
                {
                    int processId = Convert.ToInt32(processIdValue);

                    using var process =
                        Process.GetProcessById(processId);

                    if (!string.Equals(
                        process.ProcessName + ".exe",
                        processName,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }

                    logger.LogWarning(
                        "Regla activada para {ProcessName}.",
                        processName);

                    process.Kill();

                    logger.LogWarning(
                        "Proceso cerrado: {ProcessName}, PID: {ProcessId}",
                        processName,
                        processId);
                }
                catch (ArgumentException)
                {
                    logger.LogInformation(
                        "El proceso ya había terminado.");
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    logger.LogError(
                        ex,
                        "Windows denegó el cierre del proceso.");
                }
                catch (InvalidOperationException ex)
                {
                    logger.LogInformation(
                        ex,
                        "El proceso ya no está disponible.");
                }
            };

            try
            {
                processWatcher.Start();

                logger.LogInformation(
                    "Monitor activo. Reglas cargadas: {Count}",
                    GetRuleCount());

                await Task.Delay(
                    Timeout.Infinite,
                    stoppingToken);
            }
            catch (OperationCanceledException)
            {
                logger.LogInformation("TrueLockAgent detenido.");
            }
            catch (ManagementException ex)
            {
                logger.LogError(
                    ex,
                    "Error al escuchar eventos de Windows.");
            }
            finally
            {
                processWatcher.Stop();
                logger.LogInformation("TrueLockAgent finalizado.");
            }
        }

        private void ReloadBlockedProcesses(string filePath)
        {
            try
            {
                // Esperar un poco para que termine la escritura del archivo.
                Thread.Sleep(300);
                LoadBlockedProcesses(filePath);
            }
            catch (Exception ex)
            {
                logger.LogWarning(
                    ex,
                    "No se pudieron actualizar las reglas; se conservan las anteriores.");
            }
        }

        private static bool IsConfigFile(string? fileName)
        {
            return string.Equals(
                    fileName,
                    "blocked-apps.json",
                    StringComparison.OrdinalIgnoreCase)
                || string.Equals(
                    fileName,
                    "blocking-rules.json",
                    StringComparison.OrdinalIgnoreCase);
        }





        private void LoadBlockedProcesses(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    logger.LogWarning(
                        "No se encontró blocked-apps.json en {Path}",
                        filePath);
                    return;
                }

                string json = File.ReadAllText(filePath);

                var catalog = JsonSerializer.Deserialize<BlockedAppsConfig>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (catalog?.Applications is null)
                {
                    logger.LogWarning(
                        "El catálogo no contiene Applications.");
                    return;
                }

                string rulesPath = Path.Combine(
                    AppContext.BaseDirectory,
                    "blocking-rules.json");

                if (!File.Exists(rulesPath))
                {
                    logger.LogWarning(
                        "No se encontró blocking-rules.json en {Path}",
                        rulesPath);
                    return;
                }

                string rulesJson = File.ReadAllText(rulesPath);

                var rulesConfig =
                    JsonSerializer.Deserialize<BlockingRulesConfig>(
                        rulesJson,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                if (rulesConfig?.Rules is null)
                {
                    logger.LogWarning(
                        "El archivo de reglas no contiene Rules.");
                    return;
                }

                var enabledIds = rulesConfig.Rules
                    .Where(rule =>
                        rule is not null &&
                        rule.Enabled &&
                        !string.IsNullOrWhiteSpace(rule.ApplicationId))
                    .Select(rule => rule.ApplicationId!)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                string[] newRules = catalog.Applications
                    .Where(app =>
                        app is not null &&
                        !string.IsNullOrWhiteSpace(app.Id) &&
                        enabledIds.Contains(app.Id))
                    .SelectMany(app =>
                        app.BlockedProcesses ?? Array.Empty<string>())
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .Select(name => Path.GetFileName(name.Trim()))
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToArray();

                lock (rulesLock)
                {
                    blockedProcesses = newRules;
                }

                logger.LogInformation(
                    "Reglas activas cargadas: {Count}",
                    newRules.Length);
            }
            catch (JsonException ex)
            {
                logger.LogWarning(
                    ex,
                    "JSON inválido. Se conservan las reglas anteriores.");
            }
            catch (IOException ex)
            {
                logger.LogWarning(
                    ex,
                    "No se pudieron leer los archivos. Se conservan las reglas anteriores.");
            }
        }


        private int GetRuleCount()
        {
            lock (rulesLock)
            {
                return blockedProcesses.Length;
            }
        }

        private sealed class BlockedAppsConfig
        {
            public ApplicationConfig[]? Applications { get; set; }
        }
        private sealed class BlockingRulesConfig
        {
            public BlockingRule[]? Rules { get; set; }
        }

        private sealed class BlockingRule
        {
            public string? ApplicationId { get; set; }

            public bool Enabled { get; set; }
        }

        private sealed class ApplicationConfig
        {
            public string? Id { get; set; }

            public string? Name { get; set; }

            public string[]? BlockedProcesses { get; set; }
        }
    }
}
