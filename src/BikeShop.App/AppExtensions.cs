using AutoMapper;
using BikeShop.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.App;

public static class AppExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddCore();
        services.AddMediatR(typeof(AppExtensions));
        services.AddAutoMapper(ConfigMapper);
        return services;
    }

    private static void ConfigMapper(IMapperConfigurationExpression cfg)
    {
        cfg.AddMaps(typeof(AppExtensions));
    }
}