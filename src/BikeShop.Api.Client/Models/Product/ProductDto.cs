namespace BikeShop.Api.Client.Models.Product;

public class ProductDto
{
    public string? Brand { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public MoneyDto? Price { get; init; }
    
    public Guid Id { get; init; }
    
    public DateTime CreatedDate { get; set; }
}