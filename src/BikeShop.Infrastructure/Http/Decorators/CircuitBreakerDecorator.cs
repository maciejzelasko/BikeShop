using Polly;

namespace BikeShop.Infrastructure.Http.Decorators;

internal sealed class CircuitBreakerDecorator : BasePolicyDecorator
{
    public CircuitBreakerDecorator(IBikeShopHttpClient bikeShopHttpClient,CircuitBreakerDecoratorConfig config)
            :base(bikeShopHttpClient, 
                Policy.Handle<HttpRequestException>()
                    .CircuitBreakerAsync(config.ExceptionsAllowedBeforeBreaking,
                        TimeSpan.FromSeconds(config.DurationOfBreakInSeconds)))
    {
    }
    
}