using BikeShop.Infrastructure.Http.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.Infrastructure.Http;

public static class Extensions
{
    public static IServiceCollection AddBikeShopHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient()
            .AddSingleton<IBikeShopHttpClient, BikeShopHttpClient>()
            .Decorate<IBikeShopHttpClient,TimeoutDecorator>()
            .Decorate<IBikeShopHttpClient, WaitAndRetryDecorator>()
            .Decorate<IBikeShopHttpClient, CircuitBreakerDecorator>();

        return services;
    }
}