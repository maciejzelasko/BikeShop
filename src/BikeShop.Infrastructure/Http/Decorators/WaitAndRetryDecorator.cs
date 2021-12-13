using Polly;

namespace BikeShop.Infrastructure.Http.Decorators;

internal sealed class WaitAndRetryDecorator : BasePolicyDecorator
{
    public WaitAndRetryDecorator(IBikeShopHttpClient bikeShopHttpClient,RetryDecoratorConfig config)
        :base(bikeShopHttpClient,Policy.Handle<HttpRequestException>()
            .RetryAsync(config.RetryCount))
    {
    }
}