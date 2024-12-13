using Smartwyre.DeveloperTest.Calculator;
using Smartwyre.DeveloperTest.Calculator.Strategies;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Calculator;

public class RebateCalculatorTests
{
    [Fact]
    public void Calls_Strategy()
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
        Assert.True(result.IsSuccessful);
        Assert.Equal(50, result.RebateAmount);
    }

    [Fact]
    public void Fails_When_Request_Is_Null()
    {
        // Assemble
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var rebateCalculator = new RebateCalculator([new FixedAmountRebateStrategy()]);

        // Act
        var result = rebateCalculator.CalculateRebate(null, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Request must not be null", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Rebate_Is_Null()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var rebateCalculator = new RebateCalculator([new FixedAmountRebateStrategy()]);

        // Act
        var result = rebateCalculator.CalculateRebate(request, null, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Rebate must not be null", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Product_Is_Null()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };

        var rebateCalculator = new RebateCalculator([new FixedAmountRebateStrategy()]);

        // Act
        var result = rebateCalculator.CalculateRebate(request, rebate, null);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Product must not be null", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Product_Does_Not_Support_Incentive()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [] };

        var rebateCalculator = new RebateCalculator([new FixedAmountRebateStrategy()]);

        // Act
        var result = rebateCalculator.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Product does not support this incentive", result.FailureReason);
    }

    [Fact]
    public void Throws_InvalidOperationException_When_Strategy_NotFound()
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
