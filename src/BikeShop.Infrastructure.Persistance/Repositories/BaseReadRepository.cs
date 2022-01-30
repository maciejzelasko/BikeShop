using System.Data;
using BuildingBlocks.Core;
using Dapper;

namespace BikeShop.Infrastructure.Persistence.Repositories;

internal abstract class BaseReadRepository<TEntity, TId> : IReadRepository<TEntity, TId> 
    where TEntity : Entity<TId> 
    where TId : new()
{
    private readonly IDbConnection _connection;

    protected BaseReadRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    protected abstract string TableName { get; }
    
    public Task<TEntity?> GetByIdAsync(TId id) => throw new NotImplementedException();
    public Task<IEnumerable<TEntity>> GetAllAsync() => _connection.QueryAsync<TEntity>($"select * from {TableName}");
}