using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Render.HttpClients.Registrars;
using Soenneker.Render.OpenApiClientUtil.Abstract;

namespace Soenneker.Render.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class RenderOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="RenderOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRenderOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddRenderOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IRenderOpenApiClientUtil, RenderOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="RenderOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRenderOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddRenderOpenApiHttpClientAsSingleton()
                .TryAddScoped<IRenderOpenApiClientUtil, RenderOpenApiClientUtil>();

        return services;
    }
}
