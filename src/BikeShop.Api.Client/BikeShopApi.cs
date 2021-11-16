using BikeShop.Api.Client.Models;
using RestEase;

namespace BikeShop.Api.Client;

internal static class BikeShopApiPaths
{
    private const string Base = "/api/";

    public const string Product = $"{Base}product/";
}

[AllowAnyStatusCode]
public interface IBikeShopApi
{
    [Get(BikeShopApiPaths.Product)]
    Task<Response<IEnumerable<ProductDto>>> GetAllAsync(CancellationToken cancellationToken);

    [Get($"{BikeShopApiPaths.Product}{{id}}")]
    Task<Response<ProductDto>> GetByIdAsync([Path] int id, CancellationToken cancellationToken);
}