using Polly;

namespace BikeShop.Infrastructure.Http.Decorators;

internal sealed class CircuitBreakerDecorator : BasePolicyDecorator
{
    public CircuitBreakerDecorator(IBikeShopHttpClient bikeShopHttpClient)
            :base(bikeShopHttpClient, 
                Policy.Handle<HttpRequestException>()
                    .CircuitBreakerAsync(exceptionsAllowedBeforeBreaking: 2,
                        durationOfBreak: TimeSpan.FromSeconds(2)))
    {
    }
    
}