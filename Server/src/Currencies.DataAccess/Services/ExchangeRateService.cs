using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Models;

namespace Currencies.DataAccess.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly TableContext _dbContext;

    public ExchangeRateService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ExchangeRateDto> CreateExchangeRateAsync(BaseExchangeRateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteExchangeRateAsync(int exchangeRateId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ExchangeRateDto> GetExchangeRateByIdAsync(int currencyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ExchangeRateDto> UpdateExchangeRateAsync(int exchangeRateId, BaseExchangeRateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}