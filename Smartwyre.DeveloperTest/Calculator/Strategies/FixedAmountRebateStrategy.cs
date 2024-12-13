using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies;

public class FixedAmountRebateStrategy : IRebateStrategy
{
    public IncentiveType IncentiveType { get; private set; } = IncentiveType.FixedAmount;

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (rebate.Amount <= 0)
        {
            return CalculateRebateResult.Failure("Amount must be greater than zero");
        }

        var amount = rebate.Amount;

        return CalculateRebateResult.Success(amount);
    }
}
