namespace Currencies.Contracts.ModelDtos.ExchangeRate;

public class ExchangeRateDto
{
    public int Id { get; set; }
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Rate { get; set; }
}
