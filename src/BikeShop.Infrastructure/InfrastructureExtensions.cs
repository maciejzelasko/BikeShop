using AutoMapper;
using BikeShop.Core.Features.Product;
using BikeShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(ConfigMapper);

        return services.AddSingleton<IProductRepository, ProductRepository>();
    }

    private static void ConfigMapper(IMapperConfigurationExpression cfg) => 
        cfg.AddMaps(typeof(InfrastructureExtensions));
}