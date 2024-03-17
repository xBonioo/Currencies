﻿namespace Currencies.Contracts.ModelDtos.ExchangeRate;

public class BaseExchangeRateDto
{
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Rate { get; set; }
}
