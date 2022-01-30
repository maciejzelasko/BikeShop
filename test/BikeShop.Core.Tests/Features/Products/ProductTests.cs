using AutoFixture;
using BikeShop.Core.Features.Products;
using BikeShop.Core.SharedKernel.ValueObjects;
using FluentAssertions;
using Xunit;

namespace BikeShop.Core.Tests.Features.Products;

public class ProductTests
{
    [Fact]
    public void Update_ValueIsNegative_ReturnsFail()
    {
        // arrange
        var fixture = new Fixture();
        var product = fixture.Create<Product>();

        // act
        var result = product.UpdatePrice(-100, Currency.GBP);

        // assert
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public void Update_CurrencyIsUnknown_ReturnsFail()
    {
        // arrange
        var fixture = new Fixture();
        var product = fixture.Create<Product>();
        
        // act
        var result = product.UpdatePrice(100, Currency.Unknown);

        // assert
        result.IsFailed.Should().BeTrue();
    }
}