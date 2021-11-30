using System.Runtime.CompilerServices;
using AutoMapper;
using BikeShop.App.BuildingBlocks;
using BikeShop.App.Features.Products;
using BikeShop.Core.Features.Products;
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
        services.AddMapper<Product, ProductDto>();

    private static void ConfigMapper(IMapperConfigurationExpression cfg) =>
        cfg.AddMaps(typeof(InfrastructureExtensions));

    private static IServiceCollection AddMapper<TFrom, TTo>(this IServiceCollection services) => 
        services.AddSingleton<IMapper<TFrom, TTo>, Mapper<TFrom, TTo>>();
}