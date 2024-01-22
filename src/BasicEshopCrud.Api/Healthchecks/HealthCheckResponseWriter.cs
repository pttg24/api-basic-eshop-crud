using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BasicEshopCrud.Api.Healthchecks;

public class HealthCheckResponseWriter
{
    public async static Task WriteResponseAsync(HttpContext httpContext, HealthReport result)
    {
        var status = result.Status;

        var response = new
        {
            status = status.ToString(),
            results = result.Entries.ToDictionary(o => o.Key,
                o => new
                {
                    status = o.Value.Status.ToString(),
                    duration = $"{o.Value.Duration.TotalMilliseconds}ms",
                    description = o.Value.Description,
                    data = o.Value.Data
                }
            )
        };

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });

        // We don't want to kill instances if degraded so return OK for that too
        httpContext.Response.StatusCode = (int)(status == HealthStatus.Unhealthy ? HttpStatusCode.ServiceUnavailable : HttpStatusCode.OK);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.ContentLength = json.Length;
        await httpContext.Response.WriteAsync(json).ConfigureAwait(false);
        await httpContext.Response.CompleteAsync().ConfigureAwait(false);
    }
}