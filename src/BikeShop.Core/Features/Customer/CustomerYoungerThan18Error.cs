using FluentResults;

namespace BikeShop.Core.Features.Customer;

public class CustomerYoungerThan18Error : Error
{
    private const string CustomerShouldOlderThan18 = "Customer is underaged";

    public CustomerYoungerThan18Error() : base(CustomerShouldOlderThan18)
    {
    }

    public CustomerYoungerThan18Error(Error causedBy) : base(CustomerShouldOlderThan18, causedBy)
    {
    }
}