using System.Net;
using BikeShop.API.Tests.BuildingBlocks;
using FluentAssertions;
using Xunit;

namespace BikeShop.API.Tests.UseCases.Products.GetById;

[Collection(BikeShopAppCollection.Name)]
public class EndpointTests
{
    public EndpointTests(BikeShopAppFixture fixture)
    {
        Fixture = fixture;
    }

    private BikeShopAppFixture Fixture { get; }
    
    [Fact]
    public async Task EndpointsReturnBadRequestIfProductIdIsEmpty()
    {
        // Arrange
        var api = Fixture.GetBikeShopApiClient();
        
        // Act
        var response = await api.GetByIdAsync(Guid.Empty, CancellationToken.None);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response.Content.Should().BeNull();
    }
}