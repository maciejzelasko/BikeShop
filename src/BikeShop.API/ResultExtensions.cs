using BuildingBlocks.UseCases.Errors;
using FluentResults;

namespace BikeShop.API;

public static class ResultExtensions
{
    public static IResult HandleErrorResult(this ResultBase result)
    {
        if (result.HasError<ValidationError>()) {
            var validationErrors = result.Errors.OfType<ValidationError>()
                .ToDictionary(k => k.Code, v => new[] { v.Message });
            return Results.ValidationProblem(validationErrors, statusCode: StatusCodes.Status400BadRequest);    
        }
        
        return Results.Problem(detail: result.Errors.FirstOrDefault()?.Message);
    }
}