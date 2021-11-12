namespace BikeShop.Core.BuildingBlocks;

public interface IRepository<TEntity>
{
    Task<TEntity> GetByIdAsync(Guid id);

    Task<IEnumerable<TEntity>> GetAllAsync();
}