using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Serilog;

namespace ERP.MVC.Infrastructure.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the incoming request
            Log.Information("Incoming request: {Method} {Path}", context.Request.Method, context.Request.Path);

            // Start timing the request
            var stopwatch = Stopwatch.StartNew();

            await _next(context); // Call the next middleware

            // Log the outgoing response
            stopwatch.Stop();
            Log.Information("Outgoing response: {StatusCode} in {ElapsedMilliseconds} ms", context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }
    }
}
