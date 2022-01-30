using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.CQS.Commands.Delete;

namespace BikeShop.App.UseCases.Products.Delete;

public record DeleteProductCommand(ProductId Id) : DeleteCommand<ProductId>(Id);

