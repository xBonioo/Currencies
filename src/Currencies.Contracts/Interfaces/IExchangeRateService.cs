namespace Currencies.Contracts.Interfaces;

public interface IExchangeRateService
{
    Task<decimal> GetExchangeRateAsync(int fromCurrencyId, int toCurrencyId, CancellationToken cancellationToken);
    Task<decimal> ConvertCurrencyAsync(int fromCurrencyId, int toCurrencyId, decimal amount, CancellationToken cancellationToken);
    Task UpdateExchangeRatesAsync(CancellationToken cancellationToken);
}