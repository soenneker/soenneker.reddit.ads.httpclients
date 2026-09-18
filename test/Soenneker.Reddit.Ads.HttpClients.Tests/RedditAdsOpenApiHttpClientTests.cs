using Soenneker.Reddit.Ads.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Reddit.Ads.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class RedditAdsOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IRedditAdsOpenApiHttpClient _httpclient;

    public RedditAdsOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IRedditAdsOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
