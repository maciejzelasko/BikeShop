using BikeShop.Core.Features.Products;
using BikeShop.Core.SharedKernel.ValueObjects;

namespace BikeShop.Core.Features.Products
{
    public static partial class ProductMapper
    {
        public static ProductDto AdaptToDto(this Product p1)
        {
            return p1 == null ? null : new ProductDto()
            {
                Brand = p1.Brand,
                Name = p1.Name,
                Description = p1.Description,
                Price = p1.Price,
                Id = p1.Id,
                CreatedDate = p1.CreatedDate
            };
        }
        public static ProductDto AdaptTo(this Product p2, ProductDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            ProductDto result = p3 ?? new ProductDto();
            
            result.Brand = p2.Brand;
            result.Name = p2.Name;
            result.Description = p2.Description;
            result.Price = p2.Price == null ? null : new Money(p2.Price.Value, p2.Price.Currency);
            result.Id = p2.Id;
            result.CreatedDate = p2.CreatedDate;
            return result;
            
        }
    }
}