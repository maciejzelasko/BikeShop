using BuildingBlocks.UseCases.Errors;
using FluentResults;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.UseCases.CQS;

public class PipelineValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new() 
{
    private readonly IEnumerable<IValidator> _validators;

    public PipelineValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var validationResult = await ValidateAsync(request);
        if (validationResult.IsSuccess) 
            return await next();

        var result = new TResponse();
        foreach (var reason in validationResult.Reasons)
            result.Reasons.Add(reason);

        return result;
    }

    private async Task<Result> ValidateAsync(TRequest request)
    {
        var validationFailures = (await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(new ValidationContext<TRequest>(request)))))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure != null)
            .ToList();
        
        if (validationFailures.Any())
        {
            var errorResult = validationFailures.ConvertAll(validationFailure => new ValidationError(validationFailure.PropertyName, validationFailure.ErrorMessage));
            return Result.Fail("Validation failed").WithErrors(errorResult);
        }

        return Result.Ok();
    }
}