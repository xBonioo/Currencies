namespace Currencies.Contracts.ModelDtos.User.ExchangeHistory;

public class FilterUserExchangeHistoryDto : FilterDto
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
