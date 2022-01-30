using BikeShop.Core.Features.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations.CustomerEntity;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(t => t.Id).HasConversion(new CustomerIdValueConverter());
    }
}