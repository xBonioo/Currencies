namespace Currencies.Contracts.ModelDtos.User.CurrencyAmount;

public class ConvertUserCurrencyAmountDto
{
    public string UserId { get; set; } = null!;
    public int FromCurrencyId { get; set; }
    public int UserCurrencyAmountAccountId { get; set; }
    public decimal Amount { get; set; }
}
