using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace WeatherProcessor.ProgramSettings
{
    /// <summary>
    /// Пути к директориям
    /// </summary>
    public static class DirectoryPaths
    {
        private static readonly Serilog.ILogger Log = Serilog.Log.Logger;

        /// <summary>
        /// Директория с запускаемым файлом
        /// </summary>
        [NotNull]
        public static string WorkingDirectory { get; }

        /// <summary>
        /// Директория сохранения логов.
        /// </summary>
        public static string LogsDirectory { get; }

        static DirectoryPaths()
        {
            WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            LogsDirectory = Path.Combine(WorkingDirectory, "Logs");

            Log.Information($"Logs directory: {LogsDirectory}");
        }
    }
}
