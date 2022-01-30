namespace BuildingBlocks.Core;

public abstract class Entity<TId> : IIdentifiable<TId>
    where TId : new()
{
    protected Entity(){}

    protected Entity(TId id)
    {
        Id = id;
        CreatedDate = DateTime.UtcNow;
    }

    public TId Id { get; private set; }

    public DateTime CreatedDate { get; private set; }
}