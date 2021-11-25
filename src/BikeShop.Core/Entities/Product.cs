using BikeShop.Core.BuildingBlocks;
using BikeShop.Core.Identifiers;

namespace BikeShop.Core.Entities;

public class Product : Entity<ProductId>
{
    public Product()
    {
    }

    public Product(string? brand, string? name, string? description, decimal price)
    {
        Brand = brand;
        Name = name;
        Description = description;
        Price = price;
    }

    protected override ProductId NewId() => ProductId.New();

    public string? Brand { get; private set; }

    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public decimal Price { get; private set; }

    public bool IsAvailable { get; set; }
}