using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Tests.Mocks;

internal class MockRebateDataStore : IRebateDataStore
{
    private readonly Dictionary<string, Rebate> _rebates = new()
    {
        { "rebate1", new Rebate(){ Identifier = "rebate1", Incentive = IncentiveType.FixedCashAmount, Amount = 50m } },
        { "rebate2", new Rebate(){ Identifier = "rebate2", Incentive = IncentiveType.FixedRateRebate, Percentage = 15m } },
        { "rebate3", new Rebate(){ Identifier = "rebate3", Incentive = IncentiveType.AmountPerUom, Amount = 5m } },
    };

    public Rebate GetRebate(string rebateIdentifier)
    {
        return _rebates[rebateIdentifier];
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
    }

    public List<Rebate> GetRebatesSupportedByProduct(Product product)
    {
        return _rebates.Values
            .Where(r => product.SupportedIncentiveTypes.Contains(r.Incentive))
            .ToList();
    }
}

