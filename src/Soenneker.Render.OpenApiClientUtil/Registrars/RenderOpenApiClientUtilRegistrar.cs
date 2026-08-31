using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Render.HttpClients.Registrars;
using Soenneker.Render.OpenApiClientUtil.Abstract;

namespace Soenneker.Render.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Render API client.
/// </summary>
public static class RenderOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Render API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRenderOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddRenderOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IRenderOpenApiClientUtil, RenderOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Render API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddRenderOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddRenderOpenApiHttpClientAsSingleton()
                .TryAddScoped<IRenderOpenApiClientUtil, RenderOpenApiClientUtil>();

        return services;
    }
}
