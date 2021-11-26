using BikeShop.Core.BuildingBlocks;

namespace BikeShop.Core.Features.Service;

public class Service : Entity<ServiceId>
{
    public enum ServiceType
    {
        Unknown,
        Repair = 1,
        Maintenance
    }

    public Service(ServiceType type)
    {
        Type = type;
    }

    public ServiceType Type { get; private set; }

    public static Service Repair() => new(ServiceType.Repair);

    protected override ServiceId NewId() => ServiceId.New();
}