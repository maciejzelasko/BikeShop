using BikeShop.Api.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using Refit;

namespace BikeShop.API.Tests.BuildingBlocks;

public class BikeShopAppFixture : WebApplicationFactory<Program>
{
    public IBikeShopApiClient GetBikeShopApiClient() => RestService.For<IBikeShopApiClient>(CreateClient());
}