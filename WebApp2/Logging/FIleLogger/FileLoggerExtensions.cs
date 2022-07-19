namespace WebApi1.Logging.FIleLogger
{
    public static class FileLoggerExtensions
    {

        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filepath)
        {
            builder.AddProvider(new FileLoggerProvider(filepath));
            return builder;
        }


    }
}
