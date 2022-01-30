using BikeShop.Core.SharedKernel.ValueObjects;
using BuildingBlocks.Core;
using FluentResults;
using JetBrains.Annotations;

namespace BikeShop.Core.Features.Products;

public class Product : Entity<ProductId>
{
    [UsedImplicitly]
    private Product()
    {
    }
    
    public Product(string? brand, string? name, string? description, Money? price) : base(ProductId.New())
    {
        Brand = brand;
        Name = name;
        Description = description;
        Price = price;
    }

    public string? Brand { get; private set; }

    public string? Name { get; private set; }

    public string? Description { get; private set; }
    
    public Money? Price { get; private set; }

    public Result UpdatePrice(decimal value, Currency currency)
    {
        if (value <= 0) 
        {
            return Result.Fail("Price should positive");
        }

        if (currency == Currency.Unknown) 
        {
            return Result.Fail("Currency needs be specified");
        }

        Price = new Money(value, currency);
        
        return Result.Ok();
    }
}