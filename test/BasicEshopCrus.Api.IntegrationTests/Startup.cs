#nullable enable
using System.Reflection;
using BasicEshopCrud.Api.IntegrationTests.Drivers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SolidToken.SpecFlow.DependencyInjection;

namespace BasicEshopCrud.Api.IntegrationTests;

public class Startup
{
    private static IHost? _host;
    private static IConfiguration? _configuration;

    public static void BuildAndStartHost()
    {
        var hostBuilder = new HostBuilder()
            .UseEnvironment(SpecflowEnvironment.Name)
            .ConfigureAppConfiguration(ConfigureSpecflowConfiguration)
            .ConfigureServices((hostContext, _) =>
            {
                _configuration = hostContext.Configuration;
            })
            .UseConsoleLifetime();

        _host = hostBuilder.Build();
        _host.Start();
    }

    public static void StopHost()
    {
        using var ct = new CancellationTokenSource();

        ct.Cancel();

        _host!.WaitForShutdownAsync(ct.Token).Wait(ct.Token);
    }

    [ScenarioDependencies]
    public static IServiceCollection ConfigureSpecflowServices()
    {
        var services = new ServiceCollection();
        services.Configure<BasicEshopCrudApiOptions>(_configuration!.GetSection("BasicEshopCrudApiOptions"));
        services.AddHttpClient<BasicEshopCrudApiDriver>((s, httpClient) =>
            BasicEshopCrudApiDriver.ConfigureClient(s.GetService<IOptions<BasicEshopCrudApiOptions>>()!.Value, httpClient));

        return services;
    }

    private static void ConfigureSpecflowConfiguration(HostBuilderContext context, IConfigurationBuilder configBuilder)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;

        configBuilder
            .SetBasePath(basePath)
            .AddJsonFile($"appsettings.{SpecflowEnvironment.Name}.json", optional: false)
            .AddEnvironmentVariables();

    }
}
