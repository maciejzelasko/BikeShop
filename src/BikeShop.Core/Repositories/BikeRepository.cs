using BikeShop.Core.BuildingBlocks;
using BikeShop.Core.Entities;
using Bogus;

namespace BikeShop.Core.Repositories;

public interface IBikeRepository : IRepository<Bike>
{
}

internal sealed class BikeRepository : IBikeRepository
{
    public Task<Bike> GetByIdAsync(Guid id)
    {
        var faker = GetFaker();
        return Task.FromResult(faker.Generate());
    }

    public Task<IEnumerable<Bike>> GetAllAsync()
    {
        var faker = GetFaker();
        return Task.FromResult(faker.GenerateLazy(20));
    }

    private static Faker<Bike> GetFaker() =>
        new Faker<Bike>()
            .RuleFor(x => x.Price, f => f.Random.Decimal(500, 9000));
}