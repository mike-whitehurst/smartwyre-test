using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies;

public class FixedRateRebateStrategy : IRebateStrategy
{
    public IncentiveType IncentiveType { get; private set; } = IncentiveType.FixedRateRebate;

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        var result = new CalculateRebateResult();

        if (rebate == null)
        {
            result.Success = false;
        }
        else if (product == null)
        {
            result.Success = false;
        }
        else if (!product.SupportedIncentiveTypes.Contains(IncentiveType.FixedRateRebate))
        {
            result.Success = false;
        }
        else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
        {
            result.Success = false;
        }
        else
        {
            result.RebateAmount = product.Price * rebate.Percentage * request.Volume;
            result.Success = true;
        }

        return result;
    }
}
