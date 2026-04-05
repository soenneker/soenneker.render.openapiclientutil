using Soenneker.Render.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Render.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IRenderOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<RenderOpenApiClient> Get(CancellationToken cancellationToken = default);
}
