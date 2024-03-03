using Currencies.Contracts.Interfaces;
using Currencies.Models;

namespace Currencies.DataAccess.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly TableContext _dbContext;

    public ExchangeRateService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<decimal> ConvertCurrencyAsync(int fromCurrencyId, int toCurrencyId, decimal amount)
    {
        throw new NotImplementedException();
    }

    public async Task<decimal> GetExchangeRateAsync(int fromCurrencyId, int toCurrencyId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateExchangeRatesAsync()
    {
        throw new NotImplementedException();
    }
}