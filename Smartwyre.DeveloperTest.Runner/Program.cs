using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            CalculateRebate();
        }
        while (CalculateAgain());
    }

    private static void CalculateRebate()
    {
        var rebateService = new RebateService();
        var rebateDataStore = new RebateDataStore();
        var productDataStore = new ProductDataStore();
        string userInput;

        Console.WriteLine("Welcome to the console app for calculating rebates.");
        Console.WriteLine("You will be prompted for a product, rebate, and volume.");
        Console.WriteLine("Then a rebate will be calculated for you.");

        Console.WriteLine();
        Console.WriteLine("Available products:");
        
        foreach (var product in productDataStore.GetAllProducts())
        {
            Console.WriteLine($"- Identifier: {product.Identifier}, Price: {product.Price}, Supported Rebates: {string.Join(", ", product.SupportedIncentiveTypes.ToArray())}.");
        
        }

        Console.WriteLine();
        Console.Write("Enter a product identifier: ");
        userInput = Console.ReadLine();
        Product selectedProduct = productDataStore.GetProduct(userInput);

        Console.WriteLine();
        Console.WriteLine("Available rebates (supported by the selected product):");

        foreach (var rebate in rebateDataStore.GetRebatesSupportedByProduct(selectedProduct))
        {
            Console.WriteLine($"- Identifier: {rebate.Identifier}, Incentive: {rebate.Incentive}, Amount: {rebate.Amount}, Percentage: {rebate.Percentage}.");
        }

        Console.WriteLine();
        Console.Write("Enter a rebate identifier: ");
        userInput = Console.ReadLine();
        Rebate selectedRebate = rebateDataStore.GetRebate(userInput);

        Console.WriteLine();
        Console.Write("Enter a volume decimal: ");
        userInput = Console.ReadLine();
        decimal selectedVolume = decimal.Parse(userInput);

        Console.WriteLine();
        var result = rebateService.Calculate(new CalculateRebateRequest(selectedRebate.Identifier, selectedProduct.Identifier, selectedVolume));
        Console.WriteLine($"Result: Success: {result.Success}, RebateAmount: {result.RebateAmount}.");
    }

    static public bool CalculateAgain()
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write("Do you want to calculate again [y/n]?");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                Console.WriteLine();
                return true;
            }
            if (answer == "n")
            {
                return false;
            }
        }
    }
}
