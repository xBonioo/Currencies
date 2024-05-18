using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.Response;
using Currencies.Models.Entities;

namespace Currencies.Contracts.Interfaces;

public interface IExchangeRateService : IEntityService<ExchangeRate>
{
    Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(FilterExchangeRateDto filter,CancellationToken cancellationToken);
    Task<List<ExchangeRateDto?>> CreateAsync(List<CurrencyExchangeRateDto> currencyExchangeRateList, CancellationToken cancellationToken);
    Task<ExchangeRateDto?> UpdateAsync(int id, BaseExchangeRateDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<ExchangeRate?> GetByIdFromCurrencyAsync(int fromId, int toId, CancellationToken cancellationToken);
}