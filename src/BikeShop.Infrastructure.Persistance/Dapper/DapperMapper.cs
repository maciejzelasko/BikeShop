using BikeShop.Infrastructure.Persistence.Dapper.Handlers;
using Dapper;

namespace BikeShop.Infrastructure.Persistence.Dapper;

public static class DapperConfigurator
{
    public static void Configure()
    {
        SqlMapper.AddTypeHandler(new ProductIdHandler());
        SqlMapper.AddTypeHandler(new CustomerIdHandler());
    }
}