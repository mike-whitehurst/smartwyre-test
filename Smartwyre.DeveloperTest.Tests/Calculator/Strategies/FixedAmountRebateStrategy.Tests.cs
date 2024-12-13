using Smartwyre.DeveloperTest.Calculator.Strategies;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Calculator.Strategies;

public class FixedAmountRebateStrategyTests
{
    [Fact]
    public void CalculateRebate_Returns_Result()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();
        
        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(50, result.RebateAmount);
        Assert.Null(result.FailureReason);
    }

    [Fact]
    public void CalculateRebate_Fails_When_Request_Is_Null()
    {
        // Assemble
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(null, rebate, product);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Request must not be null", result.FailureReason);
    }

    [Fact]
    public void CalculateRebate_Fails_When_Rebate_Is_Null()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, null, product);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Rebate must not be null", result.FailureReason);
    }

    [Fact]
    public void CalculateRebate_Fails_When_Product_Is_Null()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, null);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Product must not be null", result.FailureReason);
    }

    [Fact]
    public void CalculateRebate_Fails_When_Product_Does_Not_Support_Incentive()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [] };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Product does not support this incentive", result.FailureReason);
    }

    [Fact]
    public void CalculateRebate_Fails_When_Amount_Is_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 0m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Amount must be greater than zero", result.FailureReason);
    }

    [Fact]
    public void CalculateRebate_Fails_When_Amount_Is_Less_Than_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = -1m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Amount must be greater than zero", result.FailureReason);
    }
}
