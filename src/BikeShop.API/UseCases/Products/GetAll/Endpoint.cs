using BikeShop.App.UseCases.Products.GetAll;
using MediatR;

namespace BikeShop.API.UseCases.Products.GetAll;

public static class Endpoint
{
    public static void MapGetAllProducts(this IEndpointRouteBuilder app)
    {
        app.MapGet(Routes.Base, async (ISender sender, CancellationToken cancellationToken) =>
            {
                var getAllProductsQueryResult = await sender.Send(new GetAllProductsQuery(), cancellationToken);
                if (getAllProductsQueryResult.IsFailed)
                {
                    // TODO: Handle result    
                }

                return Results.Ok(getAllProductsQueryResult.Value);
            })
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}