using Polly;

namespace BikeShop.Infrastructure.Http.Decorators;

internal sealed class WaitAndRetryDecorator : BasePolicyDecorator
{
    public WaitAndRetryDecorator(IBikeShopHttpClient bikeShopHttpClient)
        :base(bikeShopHttpClient,Policy.Handle<HttpRequestException>()
            .RetryAsync(retryCount: 3))
    {
    }
}