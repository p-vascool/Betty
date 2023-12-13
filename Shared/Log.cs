namespace Betty.Shared
{
    public static class Log
    {
        private static readonly string LogFolder = "Logs";
        private static readonly string LogFileName = "Log.txt";
        private static readonly string LogFilePath = Path.Combine(LogFolder, LogFileName);

        static Log()
        {
            CreateLogsDirectory();
        }

        private static void CreateLogsDirectory()
        {
            var logsDirectory = Path.Combine(Directory.GetCurrentDirectory(),LogFolder);
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }
        }

        public static void WriteToLog(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}{Environment.NewLine}{message}";
            WriteLogEntry(logEntry);
        }

        public static void WriteToLog(Exception exception)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {exception.Message}\n{exception.StackTrace}";
            WriteLogEntry(logEntry);
        }

        private static void WriteLogEntry(string logEntry)
            => File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
    }
}
