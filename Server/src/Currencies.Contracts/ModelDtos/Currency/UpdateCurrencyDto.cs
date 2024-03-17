namespace Currencies.Contracts.ModelDtos.Currency;

public class UpdateCurrencyDto
{
    public string Name { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}