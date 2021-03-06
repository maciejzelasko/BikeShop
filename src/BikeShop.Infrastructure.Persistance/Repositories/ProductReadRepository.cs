using System.Data;
using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;

namespace BikeShop.Infrastructure.Persistence.Repositories;

internal sealed class ProductReadRepository : BaseReadRepository<Product, ProductId>
{
    public ProductReadRepository(IDbConnection connection) : base(connection)
    {
    }


    protected override string TableName => "\"Products\"";
}