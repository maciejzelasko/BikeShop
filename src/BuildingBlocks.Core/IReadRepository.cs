namespace BuildingBlocks.Core;

public interface IReadRepository<TEntity, in TId>
    where TEntity : Entity<TId>
    where TId : new()
{
    Task<TEntity?> GetByIdAsync(TId id);

    Task<IEnumerable<TEntity>> GetAllAsync();
}