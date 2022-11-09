using System.Text;

namespace WebApi2.Middleweres.Logging
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
          var thread1 = new Thread(new ParameterizedThreadStart(LogReq));        

            thread1.Start(context);  
            
            await next(context);

            LogRes(context);

        }

        private static string GetHeaders(HttpRequest request)
        {

            var stringBuilder = new StringBuilder();

            foreach (var item in request.Headers)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }

        private static string GetHeaders(HttpResponse response)
        {

            var stringBuilder = new StringBuilder();

            foreach (var item in response.Headers)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }

        void LogReq(object? obj) 
        {
            if (obj is HttpContext context)
                app.Logger.LogInformation($"Request Path: {context.Request.Path}, Date: " +
                    $"{DateTime.Now.Date.ToShortDateString()} " +
                    $"Time:{DateTime.Now.ToLongTimeString()} {DateTime.Now.Millisecond}\n" +
                    $"Request Protocol: {context.Request.Protocol}, Request Method: {context.Request.Method}\n" +
                    $"Request Headers: {GetHeaders(context.Request)}\n----------------------------------------");

        }

        void LogRes(object? obj) 
        {
            if (obj is HttpContext context)
            app.Logger.LogInformation($"Respone Status Code: {context.Response.StatusCode}, Date: " +
                $"{DateTime.Now.Date.ToShortDateString()} Time:{DateTime.Now.ToLongTimeString()} " +
                $"{DateTime.Now.Millisecond}\n" +
                $"Response Headers: {GetHeaders(context.Response)}\n");
        } 

    }


}
