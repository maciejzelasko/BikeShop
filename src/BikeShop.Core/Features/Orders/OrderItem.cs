﻿using BuildingBlocks.Core;
using JetBrains.Annotations;

namespace BikeShop.Core.Features.Orders;

public class OrderItem : Entity<OrderItemId>
{
    [UsedImplicitly]
    private OrderItem()
    {
    }

    public OrderItem(string? name)
    {
        Name = name;
    }
    
    public string? Name { get; private set; }
}