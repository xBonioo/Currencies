using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Currency;

namespace Currencies.Contracts.Interfaces;

public interface ICurrencyService
{
    Task<PageResult<CurrencyDto>> GetAllCurrenciesAsync(FilterCurrencyDto filterDto, CancellationToken cancellationToken);
    Task<CurrencyDto> GetCurrencyByIdAsync(int currencyId, CancellationToken cancellationToken);
    Task<CurrencyDto> CreateCurrencyAsync(CreateCurrencyDto createCurrencyDto, CancellationToken cancellationToken);
    Task<CurrencyDto> UpdateCurrencyAsync(int currencyId, UpdateCurrencyDto updateCurrencyDto, CancellationToken cancellationToken);
    Task<bool> DeleteCurrencyAsync(int currencyId, CancellationToken cancellationToken);
}