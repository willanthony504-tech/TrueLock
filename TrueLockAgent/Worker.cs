
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

            LoadBlockedProcesses(filePath);

            using var fileWatcher = new FileSystemWatcher(
                Path.GetDirectoryName(filePath)!,
                Path.GetFileName(filePath))
            {
                NotifyFilter = NotifyFilters.LastWrite
                    | NotifyFilters.Size
                    | NotifyFilters.FileName
                    | NotifyFilters.CreationTime
            };

            fileWatcher.Changed += (_, _) => ReloadBlockedProcesses(filePath);
            fileWatcher.Created += (_, _) => ReloadBlockedProcesses(filePath);
            fileWatcher.Renamed += (_, _) => ReloadBlockedProcesses(filePath);

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

        private void LoadBlockedProcesses(string filePath)
        {
            if (!File.Exists(filePath))
            {
                logger.LogWarning(
                    "No se encontró blocked-apps.json en {Path}",
                    filePath);
                return;
            }

            string json = File.ReadAllText(filePath);

            var config = JsonSerializer.Deserialize<BlockedAppsConfig>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (config?.BlockedProcesses is null)
            {
                logger.LogWarning(
                    "El JSON no contiene BlockedProcesses. Se conservan las reglas anteriores.");
                return;
            }

            string[] newRules = config.BlockedProcesses
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
                "Reglas actualizadas correctamente: {Count}",
                newRules.Length);
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
            public string[]? BlockedProcesses { get; set; }
        }
    }
}
