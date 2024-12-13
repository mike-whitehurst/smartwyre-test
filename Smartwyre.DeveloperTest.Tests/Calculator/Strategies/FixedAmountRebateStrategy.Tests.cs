using Smartwyre.DeveloperTest.Calculator.Strategies;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Calculator.Strategies;

public class FixedAmountRebateStrategyTests
{
    [Fact]
    public void Returns_Correct_Amount()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();
        
        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.True(result.IsSuccessful);
        Assert.Equal(50, result.RebateAmount);
        Assert.Null(result.FailureReason);
    }

    [Fact]
    public void Fails_When_Amount_Is_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 0m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Amount must be greater than zero", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Amount_Is_Less_Than_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = -1m };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] };

        var strategy = new FixedAmountRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Amount must be greater than zero", result.FailureReason);
    }
}
