using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Models.Entities;

namespace Currencies.Contracts.Interfaces;

public interface IExchangeRateService : IEntityService<ExchangeRate>
{
    Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(CancellationToken cancellationToken);
    Task<ExchangeRateDto?> CreateAsync(BaseExchangeRateDto dto, CancellationToken cancellationToken);
    Task<ExchangeRateDto?> UpdateAsync(int id, BaseExchangeRateDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}