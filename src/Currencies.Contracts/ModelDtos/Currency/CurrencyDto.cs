namespace Currencies.Contracts.ModelDtos.Currency;

public class CurrencyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public string? Description { get; set; }
}