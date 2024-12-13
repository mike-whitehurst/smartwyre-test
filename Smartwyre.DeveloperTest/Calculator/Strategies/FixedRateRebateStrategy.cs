using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies;

public class FixedRateRebateStrategy : IRebateStrategy
{
    public IncentiveType IncentiveType { get; private set; } = IncentiveType.FixedRate;

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (product.Price <= 0)
        {
            return CalculateRebateResult.Failure("Price must be greater than zero");
        }

        if (rebate.Percentage <= 0)
        {
            return CalculateRebateResult.Failure("Percentage must be greater than zero");
        }

        if (request.Volume <= 0)
        {
            return CalculateRebateResult.Failure("Volume must be greater than zero");
        }

        var amount = product.Price * rebate.Percentage * request.Volume;

        return CalculateRebateResult.Success(amount);
    }
}
