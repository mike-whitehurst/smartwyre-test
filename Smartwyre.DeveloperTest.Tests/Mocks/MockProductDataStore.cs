using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Tests.Mocks;

internal class MockProductDataStore : IProductDataStore
{
    private readonly Dictionary<string, Product> _products = new()
    {
        { "product1", new Product(){ Identifier = "product1", Price = 7m, SupportedIncentiveTypes = [IncentiveType.FixedAmount] } },
        { "product2", new Product(){ Identifier = "product2", Price = 16m, SupportedIncentiveTypes = [IncentiveType.FixedRate] } },
        { "product3", new Product(){ Identifier = "product3", Price = 25m, SupportedIncentiveTypes = [IncentiveType.AmountPerUnit] } },
    };

    public Product GetProduct(string productIdentifier)
    {
        return _products[productIdentifier];
    }

    public List<Product> GetAllProducts()
    {
        return _products.Values.ToList();
    }
}

