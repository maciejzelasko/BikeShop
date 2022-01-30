using BikeShop.App.UseCases.Products.GetById;
using BikeShop.Core.Features.Products;
using BuildingBlocks.UseCases.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.UseCases.Products.GetById;

public static class Endpoint
{
    public static void MapGetProductById(this IEndpointRouteBuilder app)
    {
        app.MapGet($"{Routes.Base}{{id}}", async ([FromRoute] Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var createProductResult = await sender.Send(new GetProductByIdQuery(new ProductId(id)), cancellationToken);
                if (createProductResult.IsFailed) 
                {
                    return createProductResult.HandleErrorResult();
                }

                return Results.Ok(createProductResult.Value);
            })
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}