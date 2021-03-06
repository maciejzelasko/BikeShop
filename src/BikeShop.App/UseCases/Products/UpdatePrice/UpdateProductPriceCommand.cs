using BikeShop.Core.Features.Products;
using BikeShop.Core.SharedKernel.ValueObjects;
using BikeShop.Core.UseCases.Products;
using BuildingBlocks.UseCases.CRUD.Commands.Update;

namespace BikeShop.App.UseCases.Products.UpdatePrice;

public record UpdateProductPriceCommand(ProductId Id, decimal Value, Currency Currency) : UpdateCommand<ProductId>(Id);