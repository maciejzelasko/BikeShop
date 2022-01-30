using BuildingBlocks.Core;

namespace BikeShop.Core.Features.Services;

public class Service : Entity<ServiceId>
{
    public enum ServiceType
    {
        Unknown,
        Repair = 1,
        Maintenance
    }

    private Service(ServiceType type) : base(ServiceId.New())
    {
        Type = type;
    }

    public ServiceType Type { get; private set; }

    public static Service Repair() => new(ServiceType.Repair);
}