using BikeShop.Core.Features.Products;
using BikeShop.Core.UseCases.Products;
using BuildingBlocks.UseCases.CRUD.Commands.Delete;

namespace BikeShop.App.UseCases.Products.Delete;

internal class DeleteProductCommandHandler : DeleteCommandHandler<DeleteProductCommand, Product, ProductId>
{
    public DeleteProductCommandHandler(IBikeShopContext context) : base(context, context.Products)
    {
    }
}