using Currencies.Contracts.Helpers;
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

    public async Task<CurrencyDto> CreateCurrencyAsync(CreateCurrencyDto createCurrencyDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCurrencyAsync(int currencyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<CurrencyDto>> GetAllCurrenciesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<CurrencyDto> GetCurrencyByIdAsync(int currencyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<CurrencyDto> UpdateCurrencyAsync(int currencyId, UpdateCurrencyDto updateCurrencyDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}