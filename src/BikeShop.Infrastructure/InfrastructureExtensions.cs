using AutoMapper;
using BikeShop.App.Features.Product;
using BikeShop.Core.Features.Product;
using BikeShop.Infrastructure.Mappers;
using BikeShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services.AddAutoMapper(ConfigMapper)
                .AddMappers()
                .AddSingleton<IProductRepository, ProductRepository>();

    private static IServiceCollection AddMappers(this IServiceCollection services) => 
        services.AddSingleton<IProductMapper, ProductMapper>();

    private static void ConfigMapper(IMapperConfigurationExpression cfg) => 
        cfg.AddMaps(typeof(InfrastructureExtensions));
}