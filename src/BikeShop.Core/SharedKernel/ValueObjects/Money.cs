namespace BikeShop.Core.SharedKernel.ValueObjects;

public record Money(decimal Value, Currency Currency);

public enum Currency
{
    Unknown,
    USD = 1,
    GBP,
    PLN
}