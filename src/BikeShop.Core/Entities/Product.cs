using BikeShop.Core.BuildingBlocks;

namespace BikeShop.Core.Entities;

public class Product : Entity
{
    public Product()
    {
    }

    public Product(string? brand, string? model, string? description, decimal price)
    {
        Brand = brand;
        Model = model;
        Description = description;
        Price = price;
    }

    public string? Brand { get; private set; }

    public string? Model { get; private set; }

    public string? Description { get; private set; }

    public decimal Price { get; private set; }
}