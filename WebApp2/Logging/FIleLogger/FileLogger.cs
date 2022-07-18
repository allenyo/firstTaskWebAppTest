namespace WebApi1.Logging
{
    public class FileLogger : ILogger, IDisposable
    {
        readonly string filePath;
        static readonly object _lock = new();

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.Information)
            return true;
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {

                File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);

            }
        }

       
    }
}
