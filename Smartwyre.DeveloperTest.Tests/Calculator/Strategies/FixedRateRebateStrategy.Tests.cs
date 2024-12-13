using Smartwyre.DeveloperTest.Calculator.Strategies;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Calculator.Strategies;

public class FixedRateRebateStrategyTests
{
    [Fact]
    public void Returns_Correct_Amount()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedRate, Percentage = 5 };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedRate] };

        var strategy = new FixedRateRebateStrategy();
        
        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.True(result.IsSuccessful);
        Assert.Equal(3500, result.RebateAmount);
        Assert.Null(result.FailureReason);
    }

    [Fact]
    public void Fails_When_Percentage_Is_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedRate, Percentage = 0 };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedRate] };

        var strategy = new FixedRateRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Percentage must be greater than zero", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Percentage_Is_Less_Than_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedRate, Percentage = -1 };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedRate] };

        var strategy = new FixedRateRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Percentage must be greater than zero", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Price_Is_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedRate, Percentage = 5 };
        var product = new Product() { Identifier = "product1", Price = 0m, SupportedIncentiveTypes = [IncentiveType.FixedRate] };

        var strategy = new FixedRateRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Price must be greater than zero", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Price_Is_Less_Than_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedRate, Percentage = 5 };
        var product = new Product() { Identifier = "product1", Price = -1m, SupportedIncentiveTypes = [IncentiveType.FixedRate] };

        var strategy = new FixedRateRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Price must be greater than zero", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Volume_Is_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 0);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedRate, Percentage = 5 };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedRate] };

        var strategy = new FixedRateRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Volume must be greater than zero", result.FailureReason);
    }

    [Fact]
    public void Fails_When_Volume_Is_Less_Than_Zero()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", -1);
        var rebate = new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedRate, Percentage = 5 };
        var product = new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedRate] };

        var strategy = new FixedRateRebateStrategy();

        // Act
        var result = strategy.CalculateRebate(request, rebate, product);

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Equal(0, result.RebateAmount);
        Assert.Equal("Volume must be greater than zero", result.FailureReason);
    }
}
