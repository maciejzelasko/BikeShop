using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using BuildingBlocks.UseCases.CRUD.Commands.Delete;

namespace BikeShop.App.UseCases.Products.Delete;

public record DeleteProductCommand(ProductId Id) : DeleteCommand<ProductId>(Id);

