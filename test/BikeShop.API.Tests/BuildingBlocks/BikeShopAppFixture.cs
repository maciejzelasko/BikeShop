using Microsoft.AspNetCore.Mvc.Testing;
using RestEase;

namespace BikeShop.API.Tests.BuildingBlocks;

public class BikeShopAppFixture : WebApplicationFactory<Program>
{
    public TApi CreateApi<TApi>()
    {
        var client = CreateClient();
        return RestClient.For<TApi>(client);
    }
}