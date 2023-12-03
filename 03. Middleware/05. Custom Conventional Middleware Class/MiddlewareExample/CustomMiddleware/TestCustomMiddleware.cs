using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareExample.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TestCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public TestCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Rodolfo\n");

            //return _next(httpContext);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TestCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseTestCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestCustomMiddleware>();
        }
    }
}
