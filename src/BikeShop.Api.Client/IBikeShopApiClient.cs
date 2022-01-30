using BikeShop.Api.Client.Models.Product;
using Refit;

namespace BikeShop.Api.Client;

internal static class BikeShopApiPaths
{
    public const string Products = "/products";
}

public interface IBikeShopApiClient
{
    [Get(BikeShopApiPaths.Products)]
    Task<ApiResponse<IEnumerable<ProductDto>>> GetAllAsync(CancellationToken cancellationToken);
    
    [Get($"{BikeShopApiPaths.Products}/{{id}}")]
    Task<ApiResponse<ProductDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    [Post(BikeShopApiPaths.Products)]
    Task<ApiResponse<ProductDto>> CreateProductAsync([Body] CreateProductRequest request, CancellationToken cancellationToken);
}