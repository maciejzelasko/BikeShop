using BikeShop.Core.Features.Customer;

namespace BikeShop.Infrastructure.Repositories;

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