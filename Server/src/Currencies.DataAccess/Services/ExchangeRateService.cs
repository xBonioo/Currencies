using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Models;
using Currencies.Models.Entities;

namespace Currencies.DataAccess.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly TableContext _dbContext;

    public ExchangeRateService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ExchangeRateDto?> CreateAsync(BaseExchangeRateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ExchangeRateDto?> UpdateAsync(int id, BaseExchangeRateDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ExchangeRate?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}