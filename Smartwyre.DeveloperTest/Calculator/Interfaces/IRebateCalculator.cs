using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Interfaces;

public interface IRebateCalculator
{
    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product);
}
