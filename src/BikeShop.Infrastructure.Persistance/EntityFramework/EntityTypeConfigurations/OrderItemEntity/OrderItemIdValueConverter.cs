using BikeShop.Core.Features.Orders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.OrderItemEntity;

public class OrderItemIdValueConverter: ValueConverter<OrderItemId, Guid>
{
    public OrderItemIdValueConverter(ConverterMappingHints? mappingHints = null)
        : base(
            id => id.Value,
            value => new OrderItemId(value),
            mappingHints
        ) { }
}