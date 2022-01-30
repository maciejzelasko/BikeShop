using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace BikeShop.Api.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBikeShopApiClient(IServiceCollection services, Uri uri) =>
        services.AddRefitClient<IBikeShopApiClient>()
            .ConfigureHttpClient(c => c.BaseAddress = uri)
            .Services;
}