using BikeShop.App.UseCases.Products.Create;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.API.UseCases.Products.Create;

public static class Endpoint
{
    public static void MapCreateProductEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.Base, async ([FromBody] CreateProductRequest request, ISender sender, CancellationToken cancellationToken) => {
                var command = request.Adapt<CreateProductCommand>();
                var createProductResult = await sender.Send(command, cancellationToken);
                if (createProductResult.IsFailed)
                {
                    return createProductResult.HandleErrorResult();
                }

                return Results.Created($"/products/{createProductResult.Value.Id.ToString()}", createProductResult.Value);
            })
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}