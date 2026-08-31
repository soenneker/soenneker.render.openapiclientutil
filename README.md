[![](https://img.shields.io/nuget/v/soenneker.render.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.render.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.render.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.render.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.render.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.render.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.render.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.render.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Render.OpenApiClientUtil

Provides a lazily initialized Render client for services, deploys, datastores, projects, environments, workflows, logs, metrics, and account resources.

## Installation

```bash
dotnet add package Soenneker.Render.OpenApiClientUtil
```

## Configuration

```json
{
  "Render": {
    "ApiKey": "your-render-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.Render.OpenApiClientUtil.Abstract;
using Soenneker.Render.OpenApiClientUtil.Registrars;

services.AddRenderOpenApiClientUtilAsSingleton();

public sealed class RenderServiceReader
{
    private readonly IRenderOpenApiClientUtil _render;

    public RenderServiceReader(IRenderOpenApiClientUtil render)
    {
        _render = render;
    }

    public async Task GetServices(CancellationToken cancellationToken)
    {
        var client = await _render.Get(cancellationToken);
        var services = await client.Services.GetAsync(request =>
        {
            request.QueryParameters.Limit = 3;
        }, cancellationToken);
    }
}
```

The underlying provider sends `Authorization: Bearer <api-key>` and targets `https://api.render.com/v1/` by default. Use `AddRenderOpenApiClientUtilAsScoped()` when each scope should have its own lazily initialized API client; both registrations reuse the singleton authenticated HTTP client provider.
