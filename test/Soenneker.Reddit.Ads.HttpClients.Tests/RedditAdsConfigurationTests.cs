using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Reddit.Ads.HttpClients.Abstract;
using Soenneker.Reddit.Ads.HttpClients.Registrars;

namespace Soenneker.Reddit.Ads.HttpClients.Tests;

public sealed class RedditAdsConfigurationTests
{
    [Test]
    public async Task Cached_client_preserves_api_path_and_authentication()
    {
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["Reddit:Ads:AccessToken"] = "test-token"
        }).Build();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton(configuration);
        services.AddRedditAdsOpenApiHttpClientAsSingleton();
        await using var provider = services.BuildServiceProvider();
        var wrapper = provider.GetRequiredService<IRedditAdsOpenApiHttpClient>();
        var client = await wrapper.Get();
        if (!ReferenceEquals(client, await wrapper.Get()))
            throw new Exception("Expected the cached HTTP client.");
        if (new Uri(client.BaseAddress!, "me").AbsoluteUri != "https://ads-api.reddit.com/api/v3/me")
            throw new Exception("Relative URLs must retain the API version path.");
        if (client.DefaultRequestHeaders.Authorization?.ToString() != "Bearer test-token")
            throw new Exception("Expected bearer authentication.");
    }
}
