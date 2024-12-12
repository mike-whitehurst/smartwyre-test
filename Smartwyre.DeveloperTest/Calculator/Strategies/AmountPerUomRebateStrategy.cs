using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies;

public class AmountPerUomRebateStrategy : IRebateStrategy
{
    public IncentiveType IncentiveType { get; private set; } = IncentiveType.AmountPerUom;

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
        else if (!product.SupportedIncentiveTypes.Contains(IncentiveType.AmountPerUom))
        {
            result.Success = false;
        }
        else if (rebate.Amount == 0 || request.Volume == 0)
        {
            result.Success = false;
        }
        else
        {
            // TODO: review bugs
            // potential bug: increments rebate amount but this is only happens once.
            // potential bug: incentive should be per uom but this is per volume.
            result.RebateAmount += rebate.Amount * request.Volume;
            result.Success = true;
        }

        return result;
    }
}
