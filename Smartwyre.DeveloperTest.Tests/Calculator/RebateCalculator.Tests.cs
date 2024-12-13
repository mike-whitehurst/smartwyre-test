using Smartwyre.DeveloperTest.Calculator;
using Smartwyre.DeveloperTest.Calculator.Strategies;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Calculator;

public class RebateCalculatorTests
{
    [Fact]
    public void CalculateRebate_Calls_Strategy()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };
        
        var rebateCalculator = new RebateCalculator([new FixedAmountRebateStrategy()]);
        
        // Act
        var result = rebateCalculator.CalculateRebate(request, rebate, product);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(50, result.RebateAmount);
    }

    [Fact]
    public void CalculateRebate_Throws_InvalidOperationException_When_Strategy_NotFound()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var rebateCalculator = new RebateCalculator([]);

        // Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => rebateCalculator.CalculateRebate(request, rebate, product));
    }
}
