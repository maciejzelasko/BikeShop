using Newtonsoft.Json;

namespace BikeShop.Infrastructure.Http;

public class BikeShopHttpClient : IBikeShopHttpClient
{
    private readonly HttpClient _httpClient;

    public BikeShopHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<TResponse?> GetAsync<TResponse>(string url, CancellationToken cancellationToken)
    {
        var httpResponse = await _httpClient.GetAsync(url, cancellationToken);
        httpResponse.EnsureSuccessStatusCode();
        var httpResponseContent = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<TResponse>(httpResponseContent);
    }

    public async Task PostAsync<TBody>(string url, TBody body, CancellationToken cancellationToken)
    {
        var serializedBody = JsonConvert.SerializeObject(body);
        var httpResponse = await _httpClient.PostAsync(url, new StringContent(serializedBody), cancellationToken);
        httpResponse.EnsureSuccessStatusCode();
    }
}