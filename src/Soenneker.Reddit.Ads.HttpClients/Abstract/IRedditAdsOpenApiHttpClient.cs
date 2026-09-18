using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Reddit.Ads.HttpClients.Abstract;

/// <summary>
/// A cached HTTP client for the Reddit Ads API, configured with a bearer access token.
/// </summary>
public interface IRedditAdsOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>Gets the shared client using Reddit:Ads configuration. The caller must not dispose it.</summary>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
