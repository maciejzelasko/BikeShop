﻿namespace BikeShop.Core.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }

    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
