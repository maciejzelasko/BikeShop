using Microsoft.AspNetCore.Diagnostics;

namespace BikeShop.API.UseCases.Errors;

public static class Endpoint
{
    public static void MapErrors(this IEndpointRouteBuilder app, ILogger logger)
    {
        app.MapGet("/errors", (HttpContext context) =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception != null)
            {
                logger.LogError(exception, "Unhandled exception");
            }

            return Results.Problem(exception?.Message, statusCode: StatusCodes.Status500InternalServerError);
        });
    }
}
