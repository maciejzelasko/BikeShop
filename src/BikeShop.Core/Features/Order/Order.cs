using BikeShop.Core.BuildingBlocks;

namespace BikeShop.Core.Features.Order;

public class Order : Entity<OrderId>
{
    protected override OrderId NewId() => OrderId.New();
}