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
        return services;
    }
}