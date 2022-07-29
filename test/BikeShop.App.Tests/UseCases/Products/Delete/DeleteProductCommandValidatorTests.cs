using BikeShop.App.UseCases.Products.Delete;
using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using FluentValidation.TestHelper;
using Xunit;

namespace BikeShop.App.Tests.UseCases.Products.Delete;

public class DeleteProductCommandValidatorTests
{
    private readonly DeleteProductCommandValidator _sut;

    public DeleteProductCommandValidatorTests()
    {
        _sut = new DeleteProductCommandValidator();
    }

    [Fact]
    public void ShouldNotHaveValidationErrorFor_Id_IfIsNotEmpty()
    {
        // Arrange
        var query = new DeleteProductCommand(ProductId.New());

        // Act
        var result = _sut.TestValidate(query);

        // Assert
        result.ShouldNotHaveValidationErrorFor(r => r.Id);
    }

    [Fact]
    public void ShouldHaveValidationError_Id_IfIsNullOrNotEmpty()
    {
        // Arrange
        var query = new DeleteProductCommand(ProductId.Empty);

        // Act
        var result = _sut.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Id);
    }
}