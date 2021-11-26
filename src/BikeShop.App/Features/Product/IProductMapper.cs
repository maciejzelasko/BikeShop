using BikeShop.App.BuildingBlocks;

namespace BikeShop.App.Features.Product;

internal interface IProductMapper : IMapper<Core.Features.Product.Product, ProductDto>
{
}