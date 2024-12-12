using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;

public interface IRebateStrategy
{
    public IncentiveType IncentiveType { get; }

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product);
}

