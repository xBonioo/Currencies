using Currencies.Common.Enum;
using Currencies.Contracts.ModelDtos.Currency;

namespace Currencies.Contracts.ModelDtos.ExchangeRate;

public class BaseExchangeRateDto
{
    public int FromCurrencyId { get; set; }
    public CurrencyDto FromCurrency { get; set; } = null!;
    public int ToCurrencyId { get; set; }
    public CurrencyDto ToCurrency { get; set; } = null!;
    public decimal Rate { get; set; }
    public bool IsActive { get; set; }
    public Direction Direction { get; set; }
}
