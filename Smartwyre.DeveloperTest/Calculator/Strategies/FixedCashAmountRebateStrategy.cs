using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies;

public class FixedCashAmountRebateStrategy : IRebateStrategy
{
    public IncentiveType IncentiveType { get; private set; } = IncentiveType.FixedCashAmount;

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        var result = new CalculateRebateResult();

        if (rebate == null)
        {
            result.Success = false;
        }
        else if (!product.SupportedIncentiveTypes.Contains(IncentiveType.FixedCashAmount))
        {
            result.Success = false;
        }
        else if (rebate.Amount == 0)
        {
            result.Success = false;
        }
        else
        {
            result.RebateAmount = rebate.Amount;
            result.Success = true;
        }

        return result;
    }
}
