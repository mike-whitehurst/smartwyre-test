using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    private readonly Dictionary<string, Product> _products = new()
    {
        { "product1", new Product(){ Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedCashAmount] } },
        { "product2", new Product(){ Identifier = "product2", Price = 16m, SupportedIncentiveTypes = [IncentiveType.FixedRateRebate] } },
        { "product3", new Product(){ Identifier = "product3", Price = 25m, SupportedIncentiveTypes = [IncentiveType.AmountPerUom] } },
    };

    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return _products[productIdentifier]; // allowing this to error if the key is not found as this is not the focus of the test.
    }

    public List<Product> GetAllProducts()
    {
        return _products.Values.ToList();
    }
}
