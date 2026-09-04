using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Render.HttpClients.Abstract;
using Soenneker.Render.OpenApiClientUtil.Abstract;
using Soenneker.Render.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Render.OpenApiClientUtil;

/// <inheritdoc cref="IRenderOpenApiClientUtil" />
public sealed class RenderOpenApiClientUtil : IRenderOpenApiClientUtil
{
    private readonly AsyncSingleton<RenderOpenApiClient> _client;

    public RenderOpenApiClientUtil(IRenderOpenApiHttpClient httpClientUtil, IConfiguration _)
    {
        _client = new AsyncSingleton<RenderOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

            return new RenderOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<RenderOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
