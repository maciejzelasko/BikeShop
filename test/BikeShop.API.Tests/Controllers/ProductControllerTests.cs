using System.Net;
using BikeShop.Api.Client;
using BikeShop.API.Tests.BuildingBlocks;
using FluentAssertions;
using Xunit;

namespace BikeShop.API.Tests.Controllers;

[Collection(BikeShopAppCollection.Name)]
public class ProductControllerTests
{
    public ProductControllerTests(BikeShopAppFixture fixture)
    {
        Fixture = fixture;
    }

    private BikeShopAppFixture Fixture { get; }

    [Fact]
    public async Task GetAllAsync_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange

        // Act
        var api = Fixture.CreateApi<IBikeShopApi>();

        var response = await api.GetAllAsync(CancellationToken.None);

        // Assert
        response.ResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}