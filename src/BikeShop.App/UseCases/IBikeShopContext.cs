using BikeShop.Core.Features.Customers;
using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.App.UseCases;

public interface IBikeShopContext : IDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<Product> Products { get; }
}