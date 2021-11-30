using BikeShop.App.BuildingBlocks.CQS.Queries;

namespace BikeShop.App.Features.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : GetByIdQuery<ProductDto>(Id);