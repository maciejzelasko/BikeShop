using Polly;
using Polly.Timeout;

namespace BikeShop.Infrastructure.Http.Decorators;

internal sealed class TimeoutDecorator : BasePolicyDecorator
{
    public TimeoutDecorator(IBikeShopHttpClient bikeShopHttpClient)
        :base(bikeShopHttpClient,
            Policy.TimeoutAsync(TimeSpan.FromSeconds(5),TimeoutStrategy.Pessimistic))
    {
    }
}