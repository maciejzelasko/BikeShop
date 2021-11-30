using BikeShop.App.BuildingBlocks;
using BikeShop.App.BuildingBlocks.CQS.QueryHandlers;
using BikeShop.Core.Features.Products;

namespace BikeShop.App.Features.Products.GetAllProducts;

internal sealed class GetAllProductsQueryHandler : GetAllQueryHandler<GetAllProductsQuery, Product, ProductDto>
{
    public GetAllProductsQueryHandler(IProductRepository bikeRepository, IMapper<Product, ProductDto> mapper) : base(
        bikeRepository, mapper)
    {
    }
}