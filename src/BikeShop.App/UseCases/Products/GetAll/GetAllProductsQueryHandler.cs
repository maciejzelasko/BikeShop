using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using BuildingBlocks.Core;
using BuildingBlocks.UseCases.CRUD.Queries.GetAll;
using MapsterMapper;

namespace BikeShop.App.UseCases.Products.GetAll;

internal sealed class GetAllProductsQueryHandler : GetAllQueryHandler<GetAllProductsQuery, Product, ProductId, ProductDto>
{
    public GetAllProductsQueryHandler(IReadRepository<Product, ProductId> bikeRepository, IMapper mapper) : base(
        bikeRepository, mapper)
    {
    }
}