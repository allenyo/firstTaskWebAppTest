namespace WebApi2.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate next;
        private readonly WebApplication app;

        public LogMiddleware(RequestDelegate next, WebApplication app)
        {
            this.next = next;
            this.app = app;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            app.Logger.LogInformation($"Request Path: {context.Request.Path} Time: {DateTime.Now.ToLongTimeString()}");

            await next.Invoke(context);

            app.Logger.LogInformation($"Response Status: {context.Response.StatusCode} Time: {DateTime.Now.ToLongTimeString()}");

      
        }
    }
}
