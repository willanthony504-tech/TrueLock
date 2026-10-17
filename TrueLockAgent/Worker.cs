
using System;
using System.Diagnostics;
using System.Management;

namespace TrueLockAgent
{
    public class Worker(ILogger<Worker> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(
                "TrueLockAgent iniciado. Escuchando eventos de procesos.");

            using var watcher = new ManagementEventWatcher(
                new WqlEventQuery(
                    "SELECT * FROM Win32_ProcessStartTrace"));

            watcher.EventArrived += (_, args) =>
            {
                var processName = args.NewEvent.Properties["ProcessName"]?.Value?.ToString();
                var processIdValue = args.NewEvent.Properties["ProcessID"]?.Value;

                if (string.IsNullOrWhiteSpace(processName) || processIdValue is null)
                    return;

                logger.LogInformation(
                    "Proceso detectado: {ProcessName}, PID: {ProcessId}",
                    processName,
                    processIdValue);

                // Regla temporal de prueba para el Bloc de notas.
                if (!string.Equals(
                    processName,
                    "notepad.exe",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                try
                {
                    int processId = Convert.ToInt32(processIdValue);

                    using var process = Process.GetProcessById(processId);

                    // Comprobar el nombre antes de actuar.
                    if (!string.Equals(
                        process.ProcessName,
                        "notepad",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }

                    process.Kill();

                    logger.LogWarning(
                        "PRUEBA: Bloc de notas cerrado. PID: {ProcessId}",
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
                        "Windows no permitió cerrar el proceso.");
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
                watcher.Start();

                // Mantener activo el servicio sin consultar procesos en bucle.
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                // El servicio se está deteniendo.
            }
            catch (ManagementException ex)
            {
                logger.LogError(
                    ex,
                    "No se pudo escuchar los eventos de procesos de Windows.");

                throw;
            }
            finally
            {
                watcher.Stop();

                logger.LogInformation("TrueLockAgent detenido.");
            }
        }
    }
}
