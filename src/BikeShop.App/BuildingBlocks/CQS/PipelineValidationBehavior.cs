using FluentResults;
using MediatR;

namespace BikeShop.App.BuildingBlocks.CQS
{
    public class PipelineValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
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
            var validationResult = Validate(request);
            if (validationResult.IsFailed)
            {
                var result = new TResponse();
                foreach (var reason in validationResult.Reasons)
                    result.Reasons.Add(reason);

                return result;
            }

            return await next();
        }

        private Result Validate(TRequest request)
        {
            var validationFailures = _validators
                .Select(validator => validator.Validate(new ValidationContext<TRequest>(request)))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null)
                .ToList();

            if (validationFailures.Any())
            {
                var error = string.Join("\r\n", validationFailures);
                return Result.Fail(error);
            }

            return Result.Ok();
        }
    }
}
