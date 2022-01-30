using BikeShop.App.UseCases.Products.UpdatePrice;
using BikeShop.Core.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.UseCases.Products.UpdatePrice;

public static class Endpoint
{
    public static void MapUpdateProductPrice(this IEndpointRouteBuilder app)
    {
        app.MapPut($"{Routes.Base}{{id:guid}}/price", async ([FromRoute] Guid id, [FromBody] UpdateProductPriceRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var updateProductPriceResult = await sender.Send(new UpdateProductPriceCommand(new ProductId(id), request.Value, request.Currency), cancellationToken);
                if (updateProductPriceResult.IsFailed) 
                {
                    
                }

                return Results.NoContent();
            })
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}