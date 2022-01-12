using BikeShop.App.Features.Products;
using BikeShop.UI.Clients.Abstract;

namespace BikeShop.UI.Clients
{
    public class ProductClient : IProductClient
    {
        private readonly IEnumerable<ProductDto> _products = new List<ProductDto>()
            {
                new ProductDto { Id = Guid.Parse("462b7b91-4261-4f27-8fdc-e965cc00b551"), Brand = "Trek", Name = "Wheel", Description = "Part of bicycle that helps it move forward.", Price = 100.99M },
                new ProductDto { Id = Guid.Parse("922fceb7-2f74-4566-814e-23a05f5b73f8"), Brand = "Kross", Name = "Frame", Description = "Core of bicycle's construction.", Price = 500.50M },
                new ProductDto { Id = Guid.Parse("bf4ab7c7-8bd5-4fa0-a557-b81b585d4327"), Brand = "Merida", Name = "Wheel hub", Description = "Part of bicycle that helps turn the wheels", Price = 40.30M },
                new ProductDto { Id = Guid.Parse("19274c64-516f-462c-9145-dadef511f0f3"), Brand = "BTwin", Name = "Wheel", Description = "Part of bicycle that helps it move forward.", Price = 100.49M },
                new ProductDto { Id = Guid.Parse("998af0b1-14bf-4948-8cc1-6298a8e5929b"), Brand = "Alpina", Name = "Wheel", Description = "Part of bicycle that helps it move forward.", Price = 100.50M },
                new ProductDto { Id = Guid.Parse("15debba8-d39f-4947-a641-60d0d549b49c"), Brand = "Kellys", Name = "Tire", Description = "Part of wheel that gives it traction.", Price = 70 }
            };

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync() 
        { 
            return await Task.FromResult(_products);
        }
        
        public async Task<ProductDto> GetProductByIdAsync(Guid productId) 
        {
            return await Task.FromResult(_products.Single(x => x.Id == productId));
        }
    }
}
