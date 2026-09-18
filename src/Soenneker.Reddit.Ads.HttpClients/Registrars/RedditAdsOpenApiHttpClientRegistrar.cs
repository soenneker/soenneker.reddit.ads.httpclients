using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Reddit.Ads.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Reddit.Ads.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class RedditAdsOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="RedditAdsOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRedditAdsOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IRedditAdsOpenApiHttpClient, RedditAdsOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="RedditAdsOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRedditAdsOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IRedditAdsOpenApiHttpClient, RedditAdsOpenApiHttpClient>();

        return services;
    }
}
