using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.App.BuildingBlocks.QueryHandlers;
using BikeShop.Core.Features.Product;

namespace BikeShop.App.Features.Product.GetAllProducts;

public static class GetAllProducts
{
    public record Query : GetAllQuery<ProductDto>;

    internal sealed class QueryHandler : GetAllQueryHandler<Query, Core.Features.Product.Product, ProductDto>
    {
        public QueryHandler(IProductRepository bikeRepository, IProductMapper mapper) : base(bikeRepository, mapper)
        {
        }
    }
}