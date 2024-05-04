namespace Currencies.Contracts.ModelDtos.User.CurrencyAmount;

public class BaseUserCurrencyAmountDto
{
    public string UserId { get; set; }
    public int CurrencyId { get; set; }
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
}
