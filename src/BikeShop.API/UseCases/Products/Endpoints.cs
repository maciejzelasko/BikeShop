using BikeShop.API.UseCases.Products.Create;
using BikeShop.API.UseCases.Products.Delete;
using BikeShop.API.UseCases.Products.GetAll;
using BikeShop.API.UseCases.Products.GetById;
using BikeShop.API.UseCases.Products.UpdatePrice;

namespace BikeShop.API.UseCases.Products;

public static class Endpoints
{
    public static void MapProducts(this IEndpointRouteBuilder app)
    {
        // Create
        app.MapCreateProductEndpoint();
        // Read
        app.MapGetAllProducts();
        app.MapGetProductById();
        // Update
        app.MapUpdateProductPrice();
        // Delete
        app.MapDeleteProduct();
    }
}