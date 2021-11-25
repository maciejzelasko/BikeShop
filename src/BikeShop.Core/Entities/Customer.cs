﻿using BikeShop.Core.BuildingBlocks;
using BikeShop.Core.Identifiers;

namespace BikeShop.Core.Entities;

public class Customer : Entity<CustomerId>
{
    public Customer(string? firstName, string? lastName, DateTime dob)
    {
        FirstName = firstName;
        LastName = lastName;
        Status = CustomerStatus.New;
        Dob = dob;
    }
    
    public string? FirstName { get; private set; }

    public string? LastName { get; private set; }

    public DateTime Dob { get; private set; }

    public CustomerStatus? Status { get; private set; }

    public void Activate() => Status = CustomerStatus.Activated;

    public void Upgrade() => Status = CustomerStatus.Premium;

    protected override CustomerId New() => CustomerId.New();

    public enum CustomerStatus
    {
        New = 1,
        Activated,
        Premium
    }
}