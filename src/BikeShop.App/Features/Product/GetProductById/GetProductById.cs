using BikeShop.App.BuildingBlocks.Queries;
using BikeShop.App.BuildingBlocks.QueryHandlers;
using BikeShop.Core.Features.Product;

namespace BikeShop.App.Features.Product.GetProductById;

public static class GetProductById
{
    public record Query(Guid Id) : GetByIdQuery<ProductDto>(Id);

    internal sealed class QueryHandler : GetByIdQueryHandler<Query, Core.Features.Product.Product, ProductDto>
    {
        public QueryHandler(IProductRepository repository, IProductMapper mapper) : base(repository, mapper)
        {
        }
    }
}