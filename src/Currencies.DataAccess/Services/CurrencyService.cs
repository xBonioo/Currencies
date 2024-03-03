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

    public async Task<bool> CreateCurrencyAsync(CurrencyDto currencyDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCurrencyAsync(int currencyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CurrencyDto>> GetAllCurrenciesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<CurrencyDto> GetCurrencyByIdAsync(int currencyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCurrencyAsync(int currencyId, CurrencyDto currencyDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}