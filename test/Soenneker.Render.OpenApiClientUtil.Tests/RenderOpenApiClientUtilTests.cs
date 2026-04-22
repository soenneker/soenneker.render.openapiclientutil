using Soenneker.Render.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Render.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class RenderOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IRenderOpenApiClientUtil _openapiclientutil;

    public RenderOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IRenderOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
