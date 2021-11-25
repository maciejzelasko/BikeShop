namespace BikeShop.Core.BuildingBlocks;

public abstract class Entity<TId>
{
    protected Entity()
    {
        Id = New();
        CreatedDate = DateTime.UtcNow;
    }

    public TId Id { get; private set; }

    public DateTime CreatedDate { get; private set; }

    protected abstract TId New();
}