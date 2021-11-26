using AutoMapper;
using BikeShop.App.Features.Product;
using BikeShop.Core.Features.Product;

namespace BikeShop.Infrastructure.Mappers;

internal sealed class ProductMapper : BaseMapper<Product, ProductDto>, IProductMapper
{
    public ProductMapper(IMapper mapper) : base(mapper)
    {
    }
}