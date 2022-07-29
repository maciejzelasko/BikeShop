using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.ProductEntity;

public class ProductIdValueConverter : ValueConverter<ProductId, Guid>
{
    public ProductIdValueConverter(ConverterMappingHints? mappingHints = null)
        : base(
            id => id.Value,
            value => new ProductId(value),
            mappingHints
        ) { }
}