namespace BikeShop.Api.Client.Models;

public class ProductDto
{
    public Guid Id { get; init; }

    public string? Brand { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public decimal Price { get; init; }
}