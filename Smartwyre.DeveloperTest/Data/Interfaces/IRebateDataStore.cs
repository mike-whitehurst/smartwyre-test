using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Data.Interfaces;

public interface IRebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier);

    public void StoreCalculationResult(Rebate account, decimal rebateAmount);

    public List<Rebate> GetRebatesSupportedByProduct(Product product);
}
