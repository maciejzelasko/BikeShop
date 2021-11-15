using BikeShop.Core.BuildingBlocks;

namespace BikeShop.Core.Entities;

public class Product : Entity
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

    public string? Brand { get; private set; }

    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public decimal Price { get; private set; }
}