namespace BikeShop.Core.BuildingBlocks;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public DateTime CreatedDate { get; private set; }
}