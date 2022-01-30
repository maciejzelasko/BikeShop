using BikeShop.Core.SharedKernel;

namespace BikeShop.Infrastructure;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}