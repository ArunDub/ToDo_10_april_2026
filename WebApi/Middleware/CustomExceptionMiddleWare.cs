using Application.Helpers;
using System.Net;

namespace WebApi.Middleware
{
    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context,IWebHostEnvironment env)
        {

            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var source = !string.IsNullOrEmpty(exception.Source) ? exception.Source : string.Empty;
                if(env.IsDevelopment())
                {
                    var InnerException = exception.InnerException != null ? exception.InnerException.Message : string.Empty;
                    var StackTrace = !string.IsNullOrEmpty(exception.StackTrace) ? exception.StackTrace.Replace("\r\n", Environment.NewLine).Trim():string.Empty;
                    var htmlBody = string.Empty;//Html body can Generate for sending email
                    var response = ApiResponseBuilder.GenerateInternalServerError(null,500, $"{source}-{exception.Message}", StackTrace);
                    await context.Response.WriteAsJsonAsync(response);
                }
                else
                {
                    var response = ApiResponseBuilder.GenerateInternalServerError(null,500, $"{source}-{exception.Message}", null);
                    await context.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
