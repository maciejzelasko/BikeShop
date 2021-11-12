using BikeShop.Core.BuildingBlocks;

namespace BikeShop.Core.Entities;

public class Customer : Entity
{
    public Customer(string? firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Status = CustomerStatus.New;
    }

    public string? FirstName { get; private set; }

    public string? LastName { get; private set; }

    public CustomerStatus? Status { get; private set; }

    public void Activate()
    {
        Status = CustomerStatus.Activated;
    }

    public void Upgrade()
    {
        Status = CustomerStatus.Premium;
    }

    public enum CustomerStatus
    {
        New = 1,
        Activated,
        Premium
    }
}