namespace BikeShop.Core.SharedKernel;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}