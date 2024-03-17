namespace Currencies.Contracts.ModelDtos.ExchangeRate;

public class CreateExchangeRateDto
{
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Rate { get; set; }
}
