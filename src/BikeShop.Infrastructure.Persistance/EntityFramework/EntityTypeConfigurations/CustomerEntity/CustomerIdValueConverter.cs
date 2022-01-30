using BikeShop.Core.Features.Customers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.CustomerEntity;

public class CustomerIdValueConverter : ValueConverter<CustomerId, Guid>
{
    public CustomerIdValueConverter(ConverterMappingHints? mappingHints = null)
        : base(
            id => id.Value,
            value => new CustomerId(value),
            mappingHints
        )
    {
    }
}