﻿namespace WebApi2.Middleweres.Logging
{
    public static class LogExtensions
    {

        public static IApplicationBuilder UseLog(this IApplicationBuilder builder, WebApplication app)
        {
            return builder.UseMiddleware<LogMiddleware>(app);
        }
    }
}
