using BikeShop.Core.UseCases.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.OrderItemEntity;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(t => t.Id).HasConversion(new OrderItemIdValueConverter());
    }
}