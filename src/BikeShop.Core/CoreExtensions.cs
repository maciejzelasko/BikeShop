using BikeShop.Core.Repositories;
using BikeShop.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BikeShop.Core;

public static class CoreExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services) =>
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>()
                .AddSingleton<IProductRepository, ProductRepository>();
}