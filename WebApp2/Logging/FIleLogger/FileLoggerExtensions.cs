namespace WebApi1.Logging.FIleLogger
{
    public static class FileLoggerExtensions
    {

        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filepath)
        {
            builder.AddProvider(new FileLoggerProvider(filepath));
            return builder;
        }

        public static ILoggingBuilder Delete(this ILoggingBuilder builder)
        {

            var files = new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles("*.log");

            foreach (var file in files)
            {
                if (DateTime.UtcNow - file.CreationTimeUtc > TimeSpan.FromDays(30))
                    File.Delete(file.FullName);
            }

            return builder;
        }

    }
}
