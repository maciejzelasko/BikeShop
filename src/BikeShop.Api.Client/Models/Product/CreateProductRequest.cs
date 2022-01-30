namespace BikeShop.Api.Client.Models.Product;

public class CreateProductRequest
{
    public string? Brand { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }
    
    public MoneyDto? Price { get; init; }
}