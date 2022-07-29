using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using FluentValidation;

namespace BikeShop.App.UseCases.Products.Delete;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEqual(ProductId.Empty);
    }
}