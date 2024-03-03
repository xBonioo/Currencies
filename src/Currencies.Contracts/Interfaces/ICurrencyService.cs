using Currencies.Contracts.ModelDtos.Currency;

namespace Currencies.Contracts.Interfaces;

public interface ICurrencyService
{
    Task<IEnumerable<CurrencyDto>> GetAllCurrenciesAsync(CancellationToken cancellationToken);
    Task<CurrencyDto> GetCurrencyByIdAsync(int currencyId, CancellationToken cancellationToken);
    Task<bool> CreateCurrencyAsync(CurrencyDto currencyDto, CancellationToken cancellationToken);
    Task UpdateCurrencyAsync(int currencyId, CurrencyDto currencyDto, CancellationToken cancellationToken);
    Task DeleteCurrencyAsync(int currencyId, CancellationToken cancellationToken);
}