using FluentResults;

namespace BikeShop.Core.Features.Customers.Errors;

public class CustomerYoungerThan18Error : Error
{
    private const string CustomerShouldOlderThan18 = "Customer is underaged";

    public CustomerYoungerThan18Error() : base(CustomerShouldOlderThan18)
    {
    }
}