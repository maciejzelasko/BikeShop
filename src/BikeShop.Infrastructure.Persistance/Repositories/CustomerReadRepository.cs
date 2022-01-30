using System.Data;
using BikeShop.Core.Features.Customers;

namespace BikeShop.Infrastructure.Persistence.Repositories;

internal sealed class CustomerReadRepository : BaseReadRepository<Customer, CustomerId>
{
    public CustomerReadRepository(IDbConnection connection) : base(connection)
    {
    }

    protected override string TableName => "\"Customers\"";
}