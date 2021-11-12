using System.Runtime.CompilerServices;
using BikeShop.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo($"{nameof(BikeShop.Core)}.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace BikeShop.Core;

public static class CoreExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IBikeRepository, BikeRepository>();
        return services;
    }
}