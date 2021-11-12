using BikeShop.Core.Entities;

namespace BikeShop.Core.Repositories;

public interface IBikeRepository
{
    Task<IEnumerable<Bike>> GetAllAsync();
}

internal sealed class BikeRepository : IBikeRepository
{
    public Task<IEnumerable<Bike>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}