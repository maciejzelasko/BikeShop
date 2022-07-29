using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.CRUD.Commands.Update;
using BuildingBlocks.UseCases.Errors;
using FluentResults;

namespace BikeShop.App.UseCases.Products.UpdatePrice;

internal sealed class UpdateProductPriceCommandHandler : UpdateCommandHandler<UpdateProductPriceCommand, ProductId>
{
    private readonly IBikeShopContext _context;

    public UpdateProductPriceCommandHandler(IBikeShopContext context)
    {
        _context = context;
    }

    public override async Task<Result> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
    {
        var (productId, value, currency) = request;
        var product = await _context.Products.FindAsync(new object?[] { productId }, cancellationToken);
        if (product == null)
        {
            return Result.Fail(new NotFoundError(productId.ToString()));
        }
        
        var updatePriceResult = product.UpdatePrice(value, currency);
        if (updatePriceResult.IsFailed) 
            return updatePriceResult;
        
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}