using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.CQS.Commands.Delete;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.App.UseCases.Products.Delete;

internal class DeleteProductCommandHandler : DeleteCommandHandler<DeleteProductCommand, Product, ProductId>
{
    public DeleteProductCommandHandler(IBikeShopContext context) : base(context)
    {
        Entities = context.Products;
    }
    
    protected override DbSet<Product> Entities { get; }
}