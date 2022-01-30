using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.CQS.Queries.GetAll;

namespace BikeShop.App.UseCases.Products.GetAll;

public record GetAllProductsQuery : GetAllQuery<ProductDto>;