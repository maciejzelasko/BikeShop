using Refit;

namespace BikeShop.Api.Client;

public static class RefitExtensions
{
    public static ProblemDetails? GetProblemDetailsOrNull<TResponse>(this ApiResponse<TResponse> response)
    {
        if (response.Error is ValidationApiException validationApiException) 
        {
            return validationApiException.Content;    
        }

        return null;
    }
}