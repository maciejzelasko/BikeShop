namespace BikeShop.Infrastructure.Http;

public interface IBikeShopHttpClient
{
    Task<TResponse?> GetAsync<TResponse>(string url, CancellationToken cancellationToken);
    Task PostAsync<TBody>(string url, TBody body, CancellationToken cancellationToken);
}