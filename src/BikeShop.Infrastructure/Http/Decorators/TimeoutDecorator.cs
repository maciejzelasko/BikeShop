using Polly;
using Polly.Timeout;

namespace BikeShop.Infrastructure.Http.Decorators;

internal sealed class TimeoutDecorator : BasePolicyDecorator
{
    public TimeoutDecorator(IBikeShopHttpClient bikeShopHttpClient,TimeoutDecoratorConfig config)
        :base(bikeShopHttpClient,
            Policy.TimeoutAsync(TimeSpan.FromSeconds(config.SecondsToTimeout),TimeoutStrategy.Pessimistic))
    {
    }
}