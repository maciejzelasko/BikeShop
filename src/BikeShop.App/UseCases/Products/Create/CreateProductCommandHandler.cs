using BikeShop.Core.Features.Products;
using BikeShop.Core.SharedKernel.ValueObjects;
using BuildingBlocks.UseCases.CQS.Commands.Create;
using FluentResults;
using MapsterMapper;

namespace BikeShop.App.UseCases.Products.Create;

internal class CreateProductCommandHandler : CreateCommandHandler<CreateProductCommand, ProductDto>
{
    private readonly IBikeShopContext _context;

    public CreateProductCommandHandler(IBikeShopContext context)
    {
        _context = context;
    }

    public override async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var (brand, name, description) = request;
        var product = new Product(brand, name, description, new Money(0, Currency.PLN));
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var productDto = product.AdaptToDto();
        return Result.Ok(productDto);
    }
}