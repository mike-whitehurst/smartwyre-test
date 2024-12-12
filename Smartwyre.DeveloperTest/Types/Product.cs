using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Types;

public class Product
{
    public int Id { get; set; } // having both Id and Identifier might cause confusion, suggest picking one.
    public string Identifier { get; set; }
    public decimal Price { get; set; }
    public string Uom { get; set; } // not used but perhaps should be
    public List<IncentiveType> SupportedIncentiveTypes { get; set; }
}
