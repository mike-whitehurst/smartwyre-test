namespace Smartwyre.DeveloperTest.Types;

public class CalculateRebateRequest
{
    private readonly string _rebateIdentifier = null;
    private readonly string _productIdentifier = null;
    private readonly decimal _volume = 0;

    public string RebateIdentifier
    {
        get { return _rebateIdentifier; }
    }

    public string ProductIdentifier
    {
        get { return _productIdentifier; }
    }

    public decimal Volume
    {
        get { return _volume; }
    }

    public CalculateRebateRequest(string rebateIdentifier, string productIdentifier, decimal Volume)
    {
        _rebateIdentifier = rebateIdentifier;
        _productIdentifier = productIdentifier;
        _volume = Volume;
    }
}
