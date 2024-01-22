using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace BasicEshopCrud.Api.Healthchecks;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddServiceHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks();
        return services;
    }

    public static IApplicationBuilder UseServiceHealthChecks(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/_system/health",
                new HealthCheckOptions
                {
                    AllowCachingResponses = false,
                    ResponseWriter = HealthCheckResponseWriter.WriteResponseAsync,
                });
        });

        return app;
    }
}