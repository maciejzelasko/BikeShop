using BikeShop.App.UseCases.Products.Delete;
using BikeShop.Core.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.UseCases.Products.Delete;

public static class Endpoint
{
    public static void MapDeleteProduct(this IEndpointRouteBuilder app)
    {
        app.MapDelete($"{Routes.Base}{{id:guid}}", async ([FromRoute] Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var deleteProductResult = await sender.Send(new DeleteProductCommand(new ProductId(id)), cancellationToken);
                if (deleteProductResult.IsFailed) 
                {
                    return Results.Problem();
                }

                return Results.NoContent();
            })
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}