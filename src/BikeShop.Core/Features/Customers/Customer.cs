using BikeShop.Core.BuildingBlocks;

namespace BikeShop.Core.Features.Customers;

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

    public CustomerStatus? PreviousStatus { get; private set; }

    public CustomerStatus Status { get; private set; }

    public void Activate() => SetStatus(CustomerStatus.Activated);

    public void Upgrade() => SetStatus(CustomerStatus.Premium);

    public void Lock() => SetStatus(CustomerStatus.Locked);

    protected override CustomerId NewId() => CustomerId.New();

    private void SetStatus(CustomerStatus status)
    {
        PreviousStatus = status;
        Status = status;
    }

    public enum CustomerStatus
    {
        Unknown,
        New = 1,
        Activated,
        Premium,
        Locked
    }
}