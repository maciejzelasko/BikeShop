using System.Runtime.CompilerServices;
using AutoMapper;
using BikeShop.App.Mappers;
using BikeShop.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo($"{nameof(BikeShop.App)}.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
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