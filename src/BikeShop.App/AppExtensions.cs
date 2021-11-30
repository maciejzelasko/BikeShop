using BikeShop.App.BuildingBlocks.CQS;
using BikeShop.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.App;

public static class AppExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services) =>
        services.AddCore()
                .AddMediator();

    private static IServiceCollection AddMediator(this IServiceCollection services) =>
        services.AddMediatR(typeof(AppExtensions))
                .AddSingleton(typeof(PipelineValidationBehavior<,>));
}