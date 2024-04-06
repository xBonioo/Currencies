namespace Currencies.Contracts.ModelDtos.User.CurrencyAmount;

public class BaseUserCurrencyAmountDto
{
    public string UserId { get; set; } = null!;
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
}
