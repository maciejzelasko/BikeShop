using BikeShop.Core.Features.Products;
using FluentValidation;

namespace BikeShop.App.UseCases.Products.GetById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEqual(ProductId.Empty);
    }
}