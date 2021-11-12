using BikeShop.Core.BuildingBlocks;
using BikeShop.Core.Entities;

namespace BikeShop.Core.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
}

internal sealed class CustomerRepository : ICustomerRepository
{
    public Task<Customer> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}