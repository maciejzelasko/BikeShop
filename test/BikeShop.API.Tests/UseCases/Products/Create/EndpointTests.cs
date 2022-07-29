using System.Net;
using BikeShop.Api.Client;
using BikeShop.Api.Client.Models.Product;
using BikeShop.API.Tests.BuildingBlocks;
using FluentAssertions;
using Newtonsoft.Json;
using Refit;
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
    public async Task Endpoint_RequestIsValid_ReturnsCreatedStatusCode()
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
        response.Content.Should().NotBeNull();
        response.Content?.Id.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task Endpoint_RequestIsNotValid_ReturnsBadRequestStatusCode()
    {
        // Arrange
        var api = Fixture.GetBikeShopApiClient();
        var request = new CreateProductRequest
        {
            Brand = null,
            Name = null,
            Description = "Lightweight climbing road bike"
        };
        
        // Act
        var result = await RefitRunner.Execute(() => api.CreateProductAsync(request, CancellationToken.None));

        // Assert
        var (response, problemDetails) = result.ValueOrDefault; 
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        problemDetails.Status.Should().Be(400);
    }
}