using BikeShop.App.UseCases.Products.Create;
using FluentValidation.TestHelper;
using Xunit;

namespace BikeShop.App.Tests.UseCases.Products.Create;

public class CreateProductCommandValidatorTests
{
    private readonly CreateProductCommandValidator _sut;

    public CreateProductCommandValidatorTests()
    {
        _sut = new CreateProductCommandValidator();
    }

    [Fact]
    public void ShouldNotHaveValidationErrorFor_Brand_IfIsNotEmpty()
    {
        // Arrange
        var query = new CreateProductCommand("Kross", null, null);

        // Act
        var result = _sut.TestValidate(query);

        // Assert
        result.ShouldNotHaveValidationErrorFor(r => r.Brand);
    }
    
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [Theory]
    public void ShouldHaveValidationErrorFor_Brand_IfIsNullOrEmpty(string brand)
    {
        // Arrange
        var query = new CreateProductCommand(brand, null, null);

        // Act
        var result = _sut.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Brand);
    }
    
    [Fact]
    public void ShouldNotHaveValidationErrorFor_Name_IfIsNotEmpty()
    {
        // Arrange
        var query = new CreateProductCommand(null, "Esker", null);

        // Act
        var result = _sut.TestValidate(query);

        // Assert
        result.ShouldNotHaveValidationErrorFor(r => r.Name);
    }
    
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [Theory]
    public void ShouldHaveValidationErrorFor_Name_IfIsNullOrEmpty(string name)
    {
        // Arrange
        var query = new CreateProductCommand(null, name, null);

        // Act
        var result = _sut.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Brand);
    }
}