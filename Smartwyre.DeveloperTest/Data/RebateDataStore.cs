using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

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
        return _rebates[rebateIdentifier]; // allowing this to error if the key is not found as this is not the focus of the test.
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount) // account param probably shouldn't be type Rebate
    {
        // Update account in database, code removed for brevity
    }

    public List<Rebate> GetRebatesSupportedByProduct(Product product)
    {
        return _rebates.Values
            .Where(r => product.SupportedIncentiveTypes.Contains(r.Incentive))
            .ToList();
    }
}
