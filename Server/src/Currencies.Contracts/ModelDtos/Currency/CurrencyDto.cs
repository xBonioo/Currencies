namespace Currencies.Contracts.ModelDtos.Currency;

public class CurrencyDto : BaseCurrencyDto
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}