using Serilog;
using Serilog.Events;

namespace WetherProcessor.ProgramSettings
{
    /// <summary>
    /// Настройки Serilog
    /// </summary>
    public static class SerilogSetting
    {
        /// <summary>
        /// Имя вайла лога
        /// </summary>
        public static string FileLogName => "WetherProcessor.log";

        /// <summary>
        /// Настроить Serilog
        /// </summary>
        /// <param name="builder">Билдер приложения</param>
        public static void SetSerilog(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            var log = Log.ForContext<Program>();
            const string logTemplateConsole = "[{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";
            const string logTemplateFile = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";

            if (!Directory.Exists(DirectoryPaths.LogsDirectory))
            {
                try
                {
                    Directory.CreateDirectory(DirectoryPaths.LogsDirectory);
                    log.Information($"Create directory {DirectoryPaths.LogsDirectory} for logs");
                }
                catch
                {
                    log.Error($"Can't find or create directory {DirectoryPaths.LogsDirectory} for logs");
                    return;
                }
            }

            builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .WriteTo.Console(outputTemplate: logTemplateConsole)
                .WriteTo.File(
                    outputTemplate: logTemplateFile,
                    path: Path.Combine(DirectoryPaths.LogsDirectory, FileLogName),
                    shared: true,
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 128 * 1024 * 1024
                )
            );
        }
    }
}
