using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Server
{
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;

        public TimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Response.SupportsTrailers())
            {
                httpContext.Response.DeclareTrailer("Server-Timing");

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                await _next(httpContext);

                stopWatch.Stop();

                // Not yet supported in any browser dev tools
                httpContext.Response.AppendTrailer("Server-Timing", $"app;dur={stopWatch.ElapsedMilliseconds}.0");
            }
        }
    }
}