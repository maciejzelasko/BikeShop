using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using BuildingBlocks.Core;
using BuildingBlocks.UseCases.CRUD.Queries.GetById;
using MapsterMapper;

namespace BikeShop.App.UseCases.Products.GetById;

internal sealed class GetProductByIdQueryHandler : GetByIdQueryHandler<GetProductByIdQuery, Product, ProductId, ProductDto>
{
    public GetProductByIdQueryHandler(IReadRepository<Product, ProductId> repository, IMapper mapper) : base(
        repository, mapper)
    {
    }
}