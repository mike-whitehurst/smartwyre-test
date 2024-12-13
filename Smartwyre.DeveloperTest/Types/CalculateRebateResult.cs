namespace Smartwyre.DeveloperTest.Types;

public class CalculateRebateResult
{
    public bool IsSuccessful { get; set; }
    public decimal RebateAmount { get; set; }
    public string FailureReason { get; set; }

    public static CalculateRebateResult Failure(string reason)
    {
        var result = new CalculateRebateResult();
        result.IsSuccessful = false;
        result.FailureReason = reason;
        return result;
    }

    public static CalculateRebateResult Success(decimal amount)
    {
        var result = new CalculateRebateResult();
        result.IsSuccessful = true;
        result.RebateAmount = amount;
        return result;
    }
}
