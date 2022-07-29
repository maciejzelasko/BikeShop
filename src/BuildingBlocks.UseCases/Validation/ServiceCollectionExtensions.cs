using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.UseCases.Validation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPipelineValidationBehavior(this IServiceCollection services) => services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
}