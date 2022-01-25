using BikeShop.App.Features.Products;

namespace BikeShop.UI.Clients.Abstract
{
    public interface IProductClient
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<ProductDto> GetProductByIdAsync(Guid productId);
    }
}
