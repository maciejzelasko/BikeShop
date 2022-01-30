namespace BuildingBlocks.UseCases;

public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}