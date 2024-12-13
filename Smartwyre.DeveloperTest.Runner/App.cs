using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Runner
{
    public class App
    {
        private readonly IRebateService _rebateService;
        private readonly IProductDataStore _productDataStore;
        private readonly IRebateDataStore _rebateDataStore;

        public App(IRebateService rebateService, IProductDataStore productDataStore, IRebateDataStore rebateDataStore)
        {
            _rebateService = rebateService;
            _productDataStore = productDataStore;
            _rebateDataStore = rebateDataStore;
        }

        public void Run()
        {
            do
            {
                CalculateRebate();
            }
            while (CalculateAgain());
        }

        private void CalculateRebate()
        {
            string userInput;

            Console.WriteLine("Welcome to the console app for calculating rebates.");
            Console.WriteLine("You will be prompted for a product, rebate, and volume.");
            Console.WriteLine("Then a rebate will be calculated for you.");

            Console.WriteLine();
            Console.WriteLine("Available products:");

            foreach (var product in _productDataStore.GetAllProducts())
            {
                Console.WriteLine($"- Identifier: {product.Identifier}, Price: {product.Price}, Supported Rebates: {string.Join(", ", product.SupportedIncentiveTypes.ToArray())}.");

            }

            Console.WriteLine();
            Console.Write("Enter a product identifier: ");
            userInput = Console.ReadLine();
            Product selectedProduct = _productDataStore.GetProduct(userInput);

            Console.WriteLine();
            Console.WriteLine("Available rebates (supported by the selected product):");

            foreach (var rebate in _rebateDataStore.GetRebatesSupportedByProduct(selectedProduct))
            {
                Console.WriteLine($"- Identifier: {rebate.Identifier}, Incentive: {rebate.Incentive}, Amount: {rebate.Amount}, Percentage: {rebate.Percentage}.");
            }

            Console.WriteLine();
            Console.Write("Enter a rebate identifier: ");
            userInput = Console.ReadLine();
            Rebate selectedRebate = _rebateDataStore.GetRebate(userInput);

            Console.WriteLine();
            Console.Write("Enter a volume decimal: ");
            userInput = Console.ReadLine();
            decimal selectedVolume = decimal.Parse(userInput);

            Console.WriteLine();
            var result = _rebateService.Calculate(new CalculateRebateRequest(selectedRebate.Identifier, selectedProduct.Identifier, selectedVolume));
            Console.WriteLine($"Result: Success: {result.IsSuccessful}, RebateAmount: {result.RebateAmount}."); // currency?
        }

        private static bool CalculateAgain()
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
}
