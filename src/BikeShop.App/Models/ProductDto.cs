namespace BikeShop.App.Models;

public class ProductDto
{
    public Guid Id { get; init; }

    public string? Brand { get; init; }

    public string? Model { get; init; }

    public string? Description { get; init; }

    public decimal Price { get; init; }
}