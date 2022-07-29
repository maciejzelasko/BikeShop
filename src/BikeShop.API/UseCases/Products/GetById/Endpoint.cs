using BikeShop.App.UseCases.Products.GetById;
using BikeShop.Core.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.UseCases.Products.GetById;

public static class Endpoint
{
    public static void MapGetProductById(this IEndpointRouteBuilder app)
    {
        app.MapGet($"{Routes.Base}{{id}}", async ([FromRoute] Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var getProductByIdResult = await sender.Send(new GetProductByIdQuery(new ProductId(id)), cancellationToken);
                if (getProductByIdResult.IsFailed) 
                {
                    return getProductByIdResult.HandleErrorResult();
                }

                return Results.Ok(getProductByIdResult.Value);
            })
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}