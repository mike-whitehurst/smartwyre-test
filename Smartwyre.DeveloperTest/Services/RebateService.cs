using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Calculator.Interfaces;
using Smartwyre.DeveloperTest.Services.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IProductDataStore _productDataStore;
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IRebateCalculator _rebateCalculator;

    public RebateService(IProductDataStore productDataStore, IRebateDataStore rebateDataStore, IRebateCalculator rebateCalculator)
    {
        _productDataStore = productDataStore;
        _rebateDataStore = rebateDataStore;
        _rebateCalculator = rebateCalculator;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        var result = _rebateCalculator.CalculateRebate(request, rebate, product);

        if (result.IsSuccessful)
        {
            _rebateDataStore.StoreCalculationResult(rebate, result.RebateAmount);
        }

        return result;
    }
}
