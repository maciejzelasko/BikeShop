using BikeShop.Core.SharedKernel;
using BikeShop.Core.UseCases.Customers.Errors;
using FluentResults;

namespace BikeShop.Core.UseCases.Customers;

internal sealed class CustomerFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public CustomerFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Result<Customer> Create(string? firstName, string? lastName, DateTime dob)
    {
        var validationResult = ValidateCustomerAge(dob);
        if (validationResult.IsFailed) 
        {
            return validationResult;
        }

        return Result.Ok(new Customer(firstName, lastName, dob));
    }

    private Result ValidateCustomerAge(DateTime dob)
    {
        var zeroTime = new DateTime(1, 1, 1);
        var span = _dateTimeProvider.Now - dob;
        var years = (zeroTime + span).Year - 1;

        return Result.FailIf(years < 18, new CustomerYoungerThan18Error());
    }
}