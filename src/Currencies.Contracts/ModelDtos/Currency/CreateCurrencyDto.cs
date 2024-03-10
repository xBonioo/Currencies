namespace Currencies.Contracts.ModelDtos.Currency;

public class CreateCurrencyDto
{
    public string Name { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public string? Description { get; set; }
}