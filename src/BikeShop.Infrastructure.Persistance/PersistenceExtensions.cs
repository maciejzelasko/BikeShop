using System.Data;
using BikeShop.App.UseCases;
using BikeShop.Core.Features.Customers;
using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Customers;
using BikeShop.Core.UseCases.Products;
using BikeShop.Infrastructure.Persistence.Dapper;
using BikeShop.Infrastructure.Persistence.EntityFramework;
using BikeShop.Infrastructure.Persistence.Repositories;
using BuildingBlocks.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace BikeShop.Infrastructure.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        DapperConfigurator.Configure();
        services.AddDbContext<BikeShopContext>();
        services.AddScoped<IBikeShopContext, BikeShopContext>();
        services.AddRepositories();
        services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(configuration.GetConnectionString("BikeShop")));
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddReadRepository<Customer, CustomerId, CustomerReadRepository>()
            .AddReadRepository<Product, ProductId, ProductReadRepository>();

    private static IServiceCollection AddReadRepository<TEntity, TId, TRepo>(this IServiceCollection services)
        where TEntity : Entity<TId>
        where TId : new()
        where TRepo : class, IReadRepository<TEntity, TId> =>
        services.AddScoped<IReadRepository<TEntity, TId>, TRepo>();
}