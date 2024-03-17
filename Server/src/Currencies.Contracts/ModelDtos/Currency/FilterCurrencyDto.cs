using Currencies.Contracts.Helpers;

namespace Currencies.Contracts.ModelDtos.Currency;

public class FilterCurrencyDto
{
    public string? SearchPhrase { get; set; }
    public bool? IsActive { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = PropertyForQuery.AllowedPageSizes[0];
}
