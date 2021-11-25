using BikeShop.Core.BuildingBlocks;
using BikeShop.Core.Identifiers;

namespace BikeShop.Core.Entities;

public class Order : Entity<OrderId>
{
    protected override OrderId NewId() => OrderId.New();
}