using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateServiceTests
{
    readonly RebateService _rebateService;

    public RebateServiceTests()
    {
        _rebateService = new RebateService();
    }

    [Fact]
    public void AlwaysPass()
    {
        Assert.True(true);
    }

    [Fact]
    public void Calculate()
    {
        var request = new CalculateRebateRequest();
        var result = _rebateService.Calculate(request);
        Assert.NotNull(result);
    }
}
