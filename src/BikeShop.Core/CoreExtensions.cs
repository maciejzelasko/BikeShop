using BikeShop.Core.SharedKernel;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.Core;

public static class CoreExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services) =>
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
}