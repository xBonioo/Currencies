namespace Currencies.Contracts.Interfaces;

public interface IExchangeRateService
{
    Task<decimal> GetExchangeRateAsync(int fromCurrencyId, int toCurrencyId);
    Task<decimal> ConvertCurrencyAsync(int fromCurrencyId, int toCurrencyId, decimal amount);
    Task UpdateExchangeRatesAsync();
}