using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    private readonly Dictionary<string, Rebate> _rebates = new()
    {
        { "rebate1", new Rebate(){ Identifier = "rebate1", Incentive = IncentiveType.FixedCashAmount, Amount = 50m } },
        { "rebate2", new Rebate(){ Identifier = "rebate2", Incentive = IncentiveType.FixedRateRebate, Percentage = 15m } },
        { "rebate3", new Rebate(){ Identifier = "rebate3", Incentive = IncentiveType.AmountPerUom, Amount = 5m } },
    };

    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity
        return _rebates[rebateIdentifier];
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
