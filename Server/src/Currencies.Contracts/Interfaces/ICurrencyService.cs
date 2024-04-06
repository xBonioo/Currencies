using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Models.Entities;

namespace Currencies.Contracts.Interfaces;

public interface ICurrencyService : IEntityService<Currency>
{
    Task<PageResult<CurrencyDto>> GetAllCurrenciesAsync(FilterCurrencyDto filter, CancellationToken cancellationToken);
    Task<CurrencyDto?> CreateAsync(BaseCurrencyDto dto, CancellationToken cancellationToken);
    Task<CurrencyDto?> UpdateAsync(int id, BaseCurrencyDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}