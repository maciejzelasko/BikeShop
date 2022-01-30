using BikeShop.App.UseCases.Products.GetById;
using BikeShop.Core.Features.Products;
using FluentValidation.TestHelper;
using Xunit;

namespace BikeShop.App.Tests.UseCases.Products.GetById;

public class GetProductByIdQueryValidatorTest
{
    private readonly GetProductByIdQueryValidator _sut;

    public GetProductByIdQueryValidatorTest()
    {
        _sut = new GetProductByIdQueryValidator();
    }

    [Fact]
    public void ShouldNotHaveValidationErrorForIdIdIsNotEmpty()
    {
        // Arrange
        var query = new GetProductByIdQuery(ProductId.New());

        // Act
        var result = _sut.TestValidate(query);

        // Assert
        result.ShouldNotHaveValidationErrorFor(r => r.Id);
    }

    [Fact]
    public void ShouldHaveValidationErrorIfIdIdIsNullOrNotEmpty()
    {
        // Arrange
        var request = new GetProductByIdQuery(ProductId.Empty);

        // Act
        var result = _sut.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Id);
    }
}