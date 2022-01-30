using System.Data;
using BikeShop.Core.Features.Customers;
using Dapper;

namespace BikeShop.Infrastructure.Persistence.Dapper.Handlers;

public class CustomerIdHandler : SqlMapper.TypeHandler<CustomerId>
{ 
    public override void SetValue(IDbDataParameter parameter, CustomerId value) => parameter.Value = value.Value;

    public override CustomerId Parse(object value) => new((Guid)value);
}