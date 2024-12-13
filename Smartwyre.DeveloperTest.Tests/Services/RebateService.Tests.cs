using Moq;
using Smartwyre.DeveloperTest.Calculator.Interfaces;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Services;

public class RebateServiceTests
{
    readonly IRebateService _rebateService;
    private Mock<IProductDataStore> _mockProductDataStore;
    private Mock<IRebateDataStore> _mockRebateDataStore;
    private Mock<IRebateCalculator> _mockRebateCalculator;

    public RebateServiceTests()
    {
        _mockProductDataStore = new Mock<IProductDataStore>();
        _mockRebateDataStore = new Mock<IRebateDataStore>();
        _mockRebateCalculator = new Mock<IRebateCalculator>();

        _rebateService = new RebateService(_mockProductDataStore.Object, _mockRebateDataStore.Object, _mockRebateCalculator.Object);
    }

    [Fact]
    public void Calculate_Success_Calls_StoreCalculationResult()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);

        _mockRebateDataStore
            .Setup(x => x.GetRebate("rebate1"))
            .Returns(new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m });

        _mockProductDataStore
            .Setup(x => x.GetProduct("product1"))
            .Returns(new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] });

        _mockRebateCalculator
           .Setup(x => x.CalculateRebate(It.IsAny<CalculateRebateRequest>(), It.IsAny<Rebate>(), It.IsAny<Product>()))
           .Returns(new CalculateRebateResult() { IsSuccessful = true, RebateAmount = 123 });

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccessful);
        Assert.Equal(123, result.RebateAmount);
        _mockRebateDataStore.Verify(x => x.StoreCalculationResult(It.IsAny<Rebate>(), 123), Times.Once);
    }

    [Fact]
    public void Calculate_Failure_DoesNotCall_StoreCalculationResult()
    {
        // Assemble
        var request = new CalculateRebateRequest("rebate1", "product1", 100);

        _mockRebateDataStore
            .Setup(x => x.GetRebate("rebate1"))
            .Returns(new Rebate() { Identifier = "rebate1", Incentive = IncentiveType.FixedAmount, Amount = 50m });

        _mockProductDataStore
            .Setup(x => x.GetProduct("product1"))
            .Returns(new Product() { Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] });

        _mockRebateCalculator
           .Setup(x => x.CalculateRebate(It.IsAny<CalculateRebateRequest>(), It.IsAny<Rebate>(), It.IsAny<Product>()))
           .Returns(new CalculateRebateResult() { IsSuccessful = false, RebateAmount = 0m });

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccessful);
        Assert.Equal(0m, result.RebateAmount);
        _mockRebateDataStore.Verify(x => x.StoreCalculationResult(It.IsAny<Rebate>(), 123), Times.Never);
    }
}
