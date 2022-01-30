namespace BuildingBlocks.Core;

public interface IIdentifiable<out TId>
{
    public TId Id { get; }
}