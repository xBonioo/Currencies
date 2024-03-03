using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Models;

namespace Currencies.DataAccess.Services;

public class CurrencyService : ICurrencyService
{
    private readonly TableContext _dbContext;

    public CurrencyService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateCurrencyAsync(CurrencyDto currencyDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCurrencyAsync(int currencyId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CurrencyDto>> GetAllCurrenciesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<CurrencyDto> GetCurrencyByIdAsync(int currencyId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCurrencyAsync(int currencyId, CurrencyDto currencyDto)
    {
        throw new NotImplementedException();
    }
}