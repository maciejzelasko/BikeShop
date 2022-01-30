using System.Data;
using BikeShop.Core.Features.Products;
using Dapper;

namespace BikeShop.Infrastructure.Persistence.Dapper.Handlers;

public class ProductIdHandler : SqlMapper.TypeHandler<ProductId>
{ 
    public override void SetValue(IDbDataParameter parameter, ProductId value) => parameter.Value = value.Value;

    public override ProductId Parse(object value) => new((Guid)value);
}