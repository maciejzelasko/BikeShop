using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.ProductEntity;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Id).HasConversion(new ProductIdValueConverter());
        
        var products = new List<Product> 
        {
            new("Trek", "Wheel", "Part of bicycle that helps it move forward.", null),
            new("Kross", "Frame", "Core of bicycle's construction.", null),
            new("Merida", "Wheel hub", "Part of bicycle that helps turn the wheels", null),
            new("BTwin", "Wheel", "Part of bicycle that helps it move forward.", null),
            new("Alpina", "Wheel", "Part of bicycle that helps it move forward.", null),
            new("Kellys", "Tire", "Part of wheel that gives it traction.", null)
        };
        builder.HasData(products);
        builder.OwnsOne(p => p.Price);
    }
}