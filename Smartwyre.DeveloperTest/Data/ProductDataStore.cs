using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    private readonly Dictionary<string, Product> _products = new()
    {
        { "product1", new Product(){ Identifier = "product1", Price = 7m, SupportedIncentives = SupportedIncentiveType.FixedCashAmount } },
        { "product2", new Product(){ Identifier = "product2", Price = 16m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate } },
        { "product3", new Product(){ Identifier = "product3", Price = 25m, SupportedIncentives = SupportedIncentiveType.AmountPerUom } },
    };

    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return _products[productIdentifier];
    }
}
