using BikeShop.Core.SharedKernel.ValueObjects;

namespace BikeShop.API.UseCases.Products.UpdatePrice;

public record UpdateProductPriceRequest(decimal Value, Currency Currency);