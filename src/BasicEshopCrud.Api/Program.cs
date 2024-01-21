using System.Text.Json.Serialization;
using BasicEshopCrud.Api.Extensions;
using BasicEshopCrud.Api.SerializationPolicies;
using Microsoft.AspNetCore.Mvc.Versioning;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    ConfigureHost(builder);

    ConfigureServices(builder.Services, builder.Configuration);

    var app = builder.Build();

    ConfigureApplication(app);

    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "An unhandled exception occurred during bootstrapping.");
    throw;
}
finally
{
    Log.CloseAndFlush();
}

return;

void ConfigureHost(WebApplicationBuilder builder)
{
    builder.Host.ConfigureAppConfiguration(o =>
        o.SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false)
            .AddJsonFile("serilog.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"serilog.{builder.Environment.EnvironmentName}.json", optional: true));
}

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    //services.AddServiceHealthChecks();
    services.AddBasicEshopCrudServices(configuration);

    services.AddControllers()
        //.AddPaymentDetailsController()
        .AddJsonOptions(o =>
        {
            o.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
            o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

    services.AddHttpClient();

    services.AddHttpContextAccessor();

    //services.AddObservability(configuration);

    services.AddApiVersioning(opt =>
    {
        opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        opt.AssumeDefaultVersionWhenUnspecified = true;
        opt.ReportApiVersions = true;
        opt.ApiVersionReader = new UrlSegmentApiVersionReader();
    });

    services.AddSwaggerGen();

    //services.AddVersionedApiExplorer(setup =>
    //{
    //    setup.GroupNameFormat = "'v'VVV";
    //    setup.SubstituteApiVersionInUrl = true;
    //});

    services.AddEndpointsApiExplorer();
}

void ConfigureApplication(WebApplication app)
{
    app.UseSwagger();

    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "Basic e-Shop CRUD API - v1");
    });

    app.Use((context, next) =>
    {
        context.Request.EnableBuffering();
        return next();
    });


    app.UseRouting();
    app.MapControllers();
    //app.UseServiceHealthChecks();
}