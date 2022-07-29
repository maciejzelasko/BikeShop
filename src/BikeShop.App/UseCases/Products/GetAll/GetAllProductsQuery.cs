using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.CRUD.Queries.GetAll;

namespace BikeShop.App.UseCases.Products.GetAll;

public record GetAllProductsQuery : GetAllQuery<ProductDto>;