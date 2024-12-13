using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator.Strategies;

public class AmountPerUnitRebateStrategy : IRebateStrategy
{
    public IncentiveType IncentiveType { get; private set; } = IncentiveType.AmountPerUnit;

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (rebate.Amount <= 0)
        {
            return CalculateRebateResult.Failure("Amount must be greater than zero");
        }

        if (request.Volume <= 0)
        {
            return CalculateRebateResult.Failure("Volume must be greater than zero");
        }
        
        var amount = rebate.Amount * request.Volume;

        return CalculateRebateResult.Success(amount);
    }
}
