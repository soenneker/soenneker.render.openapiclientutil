using Soenneker.Render.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Render.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class RenderOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IRenderOpenApiClientUtil _openapiclientutil;

    public RenderOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IRenderOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
