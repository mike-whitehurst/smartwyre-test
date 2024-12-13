using Smartwyre.DeveloperTest.Calculator.Interfaces;
using Smartwyre.DeveloperTest.Calculator.Strategies.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Calculator;

public class RebateCalculator : IRebateCalculator
{
    private readonly IEnumerable<IRebateStrategy> _strategies;

    public RebateCalculator(IEnumerable<IRebateStrategy> strategies)
    {
        _strategies = strategies;
    }

    public CalculateRebateResult CalculateRebate(CalculateRebateRequest request, Rebate rebate, Product product)
    {
        if (request == null)
        {
            return CalculateRebateResult.Failure("Request must not be null");
        }

        if (rebate == null)
        {
            return CalculateRebateResult.Failure("Rebate must not be null");
        }

        if (product == null)
        {
            return CalculateRebateResult.Failure("Product must not be null");
        }

        if (!product.SupportedIncentiveTypes.Contains(rebate.Incentive))
        {
            return CalculateRebateResult.Failure("Product does not support this incentive");
        }

        var strategy = _strategies.FirstOrDefault(s => s.IncentiveType == rebate.Incentive)
            ?? throw new InvalidOperationException($"No strategy found for type {rebate.Incentive}");

        return strategy.CalculateRebate(request, rebate, product);
    }
}
