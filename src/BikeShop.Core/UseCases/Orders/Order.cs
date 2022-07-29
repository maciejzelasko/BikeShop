using BuildingBlocks.Core;
using FluentResults;

namespace BikeShop.Core.UseCases.Orders;

public class Order : Entity<OrderId>
{
    private Order() : base(OrderId.New())
    {
    }

    public Order(string name)
    {
        Name = name;
        OrderItems = new List<OrderItem>();
    }
    
    public ICollection<OrderItem> OrderItems { get; private set; }

    public string Name { get; private set; }

    public Result AddItem(OrderItem item)
    {
        OrderItems.Add(item);

        return Result.Ok();
    }
}