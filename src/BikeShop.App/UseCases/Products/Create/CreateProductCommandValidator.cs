using FluentValidation;

namespace BikeShop.App.UseCases.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}