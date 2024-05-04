﻿namespace Currencies.Contracts.ModelDtos.User.CurrencyAmount;

public class ConvertUserCurrencyAmountDto
{
    public string UserId { get; set; } = null!;
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public int UserFromCurrencyAmountAccountId { get; set; }
    public int? UserToCurrencyAmountAccountId { get; set; }
    public decimal Amount { get; set; }
}
