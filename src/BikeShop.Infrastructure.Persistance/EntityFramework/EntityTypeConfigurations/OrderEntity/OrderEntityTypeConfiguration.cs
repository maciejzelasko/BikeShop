using BikeShop.Core.UseCases.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.OrderEntity;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(t => t.Id).HasConversion(new OrderIdValueConverter());
        builder
            .HasMany(o => o.OrderItems)
            .WithOne()
            .IsRequired();
    }
}