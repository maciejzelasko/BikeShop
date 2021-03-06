using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.CRUD.Commands.Create;

namespace BikeShop.App.UseCases.Products.Create;

public record CreateProductCommand(string? Brand, string? Name, string? Description) : CreateCommand<ProductDto>;

