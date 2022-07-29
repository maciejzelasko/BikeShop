using FluentResults;
using Refit;

namespace BikeShop.Api.Client;

public static class RefitRunner
{
    public static async Task<Result<(ApiResponse<TResponse> Response, ProblemDetails? ProblemDetails)>> Execute<TResponse>(Func<Task<ApiResponse<TResponse>>> func)
    {
        var response = await func();
        if (response.IsSuccessStatusCode)
        {
            return Result.Ok((response, (ProblemDetails?) null));
        }

        if (response.Error is ValidationApiException validationApiException) 
        {
            return Result.Ok((response, validationApiException.Content)).WithError(response.ReasonPhrase);    
        }        
        
        return Result.Ok((response, (ProblemDetails?) null)).WithError(response.ReasonPhrase);
    }
}