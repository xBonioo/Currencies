namespace Currencies.Contracts.ModelDtos.User.ExchangeHistory;

public class FilterUserExchangeHistoryDto : FilterDto
{
    public string UserId { get; set; } = null!;
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}
