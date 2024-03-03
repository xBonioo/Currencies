using Currencies.Contracts.ModelDtos.Currency;

namespace Currencies.Contracts.Interfaces;

public interface ICurrencyService
{
    Task<IEnumerable<CurrencyDto>> GetAllCurrenciesAsync();
    Task<CurrencyDto> GetCurrencyByIdAsync(int currencyId);
    Task<int> CreateCurrencyAsync(CurrencyDto currencyDto);
    Task UpdateCurrencyAsync(int currencyId, CurrencyDto currencyDto);
    Task DeleteCurrencyAsync(int currencyId);
}