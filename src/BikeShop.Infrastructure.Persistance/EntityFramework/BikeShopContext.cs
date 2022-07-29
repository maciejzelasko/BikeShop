using BikeShop.App.UseCases;
using BikeShop.Core.Features.Customers;
using BikeShop.Core.Features.Orders;
using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Customers;
using BikeShop.Core.UseCases.Orders;
using BikeShop.Core.UseCases.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BikeShop.Infrastructure.Persistence.EntityFramework;
public class BikeShopContext : DbContext, IBikeShopContext
{
    private readonly IConfiguration _configuration;
    
    public BikeShopContext(DbContextOptions<BikeShopContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Customer> Customers { get; init; }
    public DbSet<Order> Orders { get; init; }
    public DbSet<Product> Products { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("BikeShop"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BikeShopContext).Assembly);
    }
}