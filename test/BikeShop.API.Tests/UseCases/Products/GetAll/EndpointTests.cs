using System.Net;
using BikeShop.API.Tests.BuildingBlocks;
using FluentAssertions;
using Xunit;

namespace BikeShop.API.Tests.UseCases.Products.GetAll;

[Collection(BikeShopAppCollection.Name)]
public class EndpointTests
{
    public EndpointTests(BikeShopAppFixture fixture)
    {
        Fixture = fixture;
    }

    private BikeShopAppFixture Fixture { get; }

    [Fact]
    public async Task GetAllAsync_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var api = Fixture.GetBikeShopApiClient();

        // Act
        var response = await api.GetAllAsync(CancellationToken.None);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}