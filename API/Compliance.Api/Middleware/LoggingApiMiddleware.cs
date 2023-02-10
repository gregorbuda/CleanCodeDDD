using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System.Net;

namespace Example.Api.Middleware
{
    public class LoggingApiMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string Host = context.Request.Host.Value;

            if (!Host.Contains("local"))
            {
                if (!context.User.Identity.IsAuthenticated)
                {
                    context.Response.Clear();
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        success = false,
                        codeResult = (int)HttpStatusCode.Unauthorized,
                        message = "Unauthorized",
                        data = (string)null
                    }));
                }

            }

            await next.Invoke(context);
        }
    }

    public static class ClassWithNoImplementationMiddlewareExtensions
        {
            public static IApplicationBuilder UseClassWithNoImplementationMiddlewareExtensions(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<LoggingApiMiddleware>();
            }
        }
    
}
