using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies;

public class FixedAmountRebateStrategy : IRebateStrategy
{
    public IncentiveType IncentiveType { get; private set; } = IncentiveType.FixedAmount;

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        var result = new CalculateRebateResult();

        if (request == null)
        {
            result.FailureReason = "Request must not be null";
            result.Success = false;
        }
        else if (rebate == null)
        {
            result.FailureReason = "Rebate must not be null";
            result.Success = false;
        }
        else if (product == null)
        {
            result.FailureReason = "Product must not be null";
            result.Success = false;
        }
        else if (!product.SupportedIncentiveTypes.Contains(IncentiveType.FixedAmount))
        {
            result.FailureReason = "Product does not support this incentive";
            result.Success = false;
        }
        else if (rebate.Amount <= 0)
        {
            result.FailureReason = "Amount must be greater than zero";
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
