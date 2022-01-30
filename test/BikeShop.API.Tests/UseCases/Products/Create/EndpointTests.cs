using System.Net;
using BikeShop.Api.Client.Models.Product;
using BikeShop.API.Tests.BuildingBlocks;
using FluentAssertions;
using Xunit;

namespace BikeShop.API.Tests.UseCases.Products.Create;

[Collection(BikeShopAppCollection.Name)]
public class EndpointTests
{
    public EndpointTests(BikeShopAppFixture fixture)
    {
        Fixture = fixture;
    }

    private BikeShopAppFixture Fixture { get; }
    
    [Fact]
    public async Task EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var api = Fixture.GetBikeShopApiClient();
        var request = new CreateProductRequest
        {
            Brand = "Trek",
            Name = "Emonda",
            Description = "Lightweight climbing road bike"
        };
        
        // Act
        var response = await api.CreateProductAsync(request, CancellationToken.None);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Content.Brand.Should().Be("Trek");
    }
}