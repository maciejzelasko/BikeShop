using BuildingBlocks.UseCases.Validation;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.App;

public static class AppExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services) =>
        services.AddMediator()
                .AddMapster()
                .AddValidators();

    private static IServiceCollection AddMediator(this IServiceCollection services) =>
        services.AddMediatR(typeof(AppExtensions))
                .AddPipelineValidationBehavior();
    
    private static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        return services
            .AddSingleton(config)
            .AddScoped<IMapper, ServiceMapper>();
    }

    private static IServiceCollection AddValidators(this IServiceCollection services) =>
        services.AddValidatorsFromAssemblyContaining(typeof(AppExtensions));
}