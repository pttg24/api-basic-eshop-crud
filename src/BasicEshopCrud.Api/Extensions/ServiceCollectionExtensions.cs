using BasicEshopCrud.Domain.Interfaces;
using BasicEshopCrud.Infrastructure;
using BasicEshopCrud.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasicEshopCrud.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBasicEshopCrudServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        //Repositories
        serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();

        //Context
        serviceCollection.AddTransient(typeof(BasicEshopCrudContext));
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        //InMemoryDatabase
        serviceCollection.AddDbContext<BasicEshopCrudContext>(options => options.UseInMemoryDatabase(databaseName: "DB_EShop"));

        return serviceCollection;
    }
}
