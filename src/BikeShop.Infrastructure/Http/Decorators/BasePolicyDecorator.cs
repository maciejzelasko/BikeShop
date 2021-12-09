using Polly;

namespace BikeShop.Infrastructure.Http.Decorators;

internal abstract class BasePolicyDecorator : IBikeShopHttpClient
{
    private readonly IBikeShopHttpClient _bikeShopHttpClient;
    private readonly AsyncPolicy _policy;

    protected BasePolicyDecorator(IBikeShopHttpClient bikeShopHttpClient, AsyncPolicy policy)
    {
        _bikeShopHttpClient = bikeShopHttpClient;
        _policy = policy;
    }

    public async Task<TResponse?> GetAsync<TResponse>(string url, CancellationToken cancellationToken) =>
        await _policy.ExecuteAsync(async _ => {
                var response = await _bikeShopHttpClient.GetAsync<TResponse>(url, cancellationToken);
                return response;
            },
            cancellationToken);

    public Task PostAsync<TBody>(string url, TBody body, CancellationToken cancellationToken) => 
        _policy.ExecuteAsync(async ct => 
                await _bikeShopHttpClient.PostAsync(url,body,cancellationToken),
            cancellationToken);
}