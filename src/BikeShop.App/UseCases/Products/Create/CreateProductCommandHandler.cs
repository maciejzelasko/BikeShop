﻿using BikeShop.Core.Features.Products;
using BikeShop.Core.SharedKernel.ValueObjects;
using BuildingBlocks.UseCases.CRUD.Commands.Create;

namespace BikeShop.App.UseCases.Products.Create;

internal class CreateProductCommandHandler : CreateCommandHandler<CreateProductCommand, Product, ProductDto>
{
    public CreateProductCommandHandler(IBikeShopContext context) : base(context, context.Products)
    {
    }
    
    protected override Product CreateEntity(CreateProductCommand request)
    {
        var (brand, name, description) = request;
        return new Product(brand, name, description, new Money(0, Currency.PLN));
    }

    override protected ProductDto MapDto(Product product) => product.AdaptToDto();
}