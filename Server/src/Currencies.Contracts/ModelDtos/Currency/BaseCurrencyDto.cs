namespace Currencies.Contracts.ModelDtos.Currency;

public class BaseCurrencyDto
{
    public string Name { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}