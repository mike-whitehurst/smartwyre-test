using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Tests.Mocks;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Services;

public class RebateServiceTests
{
    readonly IRebateService _rebateService;

    public RebateServiceTests()
    {
        _rebateService = new RebateService(new MockProductDataStore(), new MockRebateDataStore());
    }

    [Fact]
    public void Calculate_FixedCashAmount()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(50, result.RebateAmount);
    }

    [Fact]
    public void Calculate_FixedRateRebate()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate2", "product2", 200);

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(48_000, result.RebateAmount);
    }

    [Fact]
    public void Calculate_AmountPerUom()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate3", "product3", 300);

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(1500, result.RebateAmount);
    }
}
