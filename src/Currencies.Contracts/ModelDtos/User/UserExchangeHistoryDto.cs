namespace Currencies.Contracts.ModelDtos.User;

public class UserExchangeHistoryDto
{
    public int Id { get; set; }
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Amount { get; set; }
    public decimal ExchangeRate { get; set; }
    public DateTime CreatedOn { get; set; }
}
