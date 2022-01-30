using BikeShop.Core.Features.Orders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.OrderEntity;

public class OrderIdValueConverter: ValueConverter<OrderId, Guid>
{
    public OrderIdValueConverter(ConverterMappingHints? mappingHints = null)
        : base(
            id => id.Value,
            value => new OrderId(value),
            mappingHints
        ) { }
}