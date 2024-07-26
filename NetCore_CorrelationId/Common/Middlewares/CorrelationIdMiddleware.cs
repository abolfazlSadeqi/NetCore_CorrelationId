using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Net.Http;

namespace NetCore_CorrelationId.Common.Middlewares;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    public CorrelationIdMiddleware(RequestDelegate next)
       => _next = next;
    public async Task Invoke(HttpContext httpContext, ICorrelationIdService service)
    {
        if (!httpContext.Request.Headers.TryGetValue("x-Correlation-Id", out StringValues correlationId))
            correlationId = service.GetCorrelationId();
        await AddToResponseHeaders(httpContext, correlationId);
        await AddcorrelationIdTolog(httpContext, correlationId);
    }
    async Task AddToResponseHeaders(HttpContext httpContext, string correlationId)
    {
        httpContext.Response.OnStarting(() =>
        {
            if (!httpContext.Response.Headers.ContainsKey("x-Correlation-Id"))
            {
                httpContext.Response.Headers["x-Correlation-Id"] = correlationId;
                return Task.CompletedTask;
            }

            httpContext.Response.Headers.Add("x-Correlation-Id", new[] { correlationId.ToString() });
            return Task.CompletedTask;
        });
    }
    async Task AddcorrelationIdTolog(HttpContext httpContext, string correlationId)
    {
        var logger = httpContext.RequestServices.GetRequiredService<ILogger<CorrelationIdMiddleware>>();
        using (logger.BeginScope("{@CorrelationId}", correlationId))
        {
            await _next(httpContext);
        }
    }

}
