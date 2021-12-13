using BikeShop.Infrastructure.Http.Decorators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.Infrastructure.Http;

public static class Extensions
{
    public static IServiceCollection AddBikeShopHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        var httpConfig = new BikeShopHttpClientConfig();
        configuration.GetSection("http").Bind(httpConfig);
        services.AddHttpClient()
            .AddSingleton<IBikeShopHttpClient, BikeShopHttpClient>();
        if (httpConfig.Decorators != null && !httpConfig.Decorators.Enabled) {
            return services;
        }

        if (httpConfig.Decorators != null && httpConfig.Decorators.Timeout.Enabled) {
            services.Decorate<IBikeShopHttpClient>(s => new TimeoutDecorator(s, httpConfig.Decorators.Timeout));
        }

        if (httpConfig.Decorators != null && httpConfig.Decorators.Retry.Enabled) {
            services.Decorate<IBikeShopHttpClient>(s => new WaitAndRetryDecorator(s, httpConfig.Decorators.Retry));
        }

        if (httpConfig.Decorators != null && httpConfig.Decorators.CircuitBreaker.Enabled) {
            services.Decorate<IBikeShopHttpClient>(s => new CircuitBreakerDecorator(s, httpConfig.Decorators.CircuitBreaker));
        }

        return services;
    }
}