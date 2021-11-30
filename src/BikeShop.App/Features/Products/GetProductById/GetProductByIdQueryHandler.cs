using BikeShop.App.BuildingBlocks;
using BikeShop.App.BuildingBlocks.CQS.QueryHandlers;
using BikeShop.Core.Features.Products;

namespace BikeShop.App.Features.Products.GetProductById;

internal sealed class GetProductByIdQueryHandler : GetByIdQueryHandler<GetProductByIdQuery, Product, ProductDto>
{
    public GetProductByIdQueryHandler(IProductRepository repository, IMapper<Product, ProductDto> mapper) : base(
        repository, mapper)
    {
    }
}