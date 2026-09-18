[![](https://img.shields.io/nuget/v/soenneker.reddit.ads.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.reddit.ads.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.reddit.ads.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.reddit.ads.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.reddit.ads.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.reddit.ads.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Reddit.Ads.HttpClients
### A thread-safe singleton HttpClient for Reddit Ads OpenAPI integration.

## Installation

```
dotnet add package Soenneker.Reddit.Ads.HttpClients
```

## Usage

Register `services.AddRedditAdsOpenApiHttpClientAsSingleton()` from
`Soenneker.Reddit.Ads.HttpClients.Registrars`, then inject `IRedditAdsOpenApiHttpClient`.

```csharp
var client = await httpClientUtil.Get(cancellationToken);
using var response = await client.GetAsync("me", cancellationToken);
response.EnsureSuccessStatusCode();
```

Configure `Reddit:Ads:AccessToken` with an OAuth access token. Optional
`Reddit:Ads:ClientBaseUrl` defaults to `https://ads-api.reddit.com/api/v3/`.
Use relative paths without a leading slash to retain `/api/v3/`.
`Reddit:Ads:AuthHeaderName` and `Reddit:Ads:AuthHeaderValueTemplate` default to
`Authorization` and `Bearer {token}`. Credentials are captured when the cached client
is created; token refresh is the application's responsibility. The wrapper owns the
HTTP client; callers must not dispose the shared instance.
