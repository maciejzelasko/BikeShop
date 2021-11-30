using BikeShop.Core.Features.Products;
using Bogus;

namespace BikeShop.Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    public Task<Product> GetByIdAsync(Guid id)
    {
        var faker = GetFaker();
        return Task.FromResult(faker.Generate());
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        var faker = GetFaker();
        return Task.FromResult(faker.GenerateLazy(20));
    }

    private static Faker<Product> GetFaker() =>
        new Faker<Product>()
            .RuleFor(x => x.Price, f => f.Random.Decimal(500, 9000));
}