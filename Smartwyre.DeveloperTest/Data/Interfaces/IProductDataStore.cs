using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Data.Interfaces;

public interface IProductDataStore
{
    public Product GetProduct(string productIdentifier);

    public List<Product> GetAllProducts();
}
