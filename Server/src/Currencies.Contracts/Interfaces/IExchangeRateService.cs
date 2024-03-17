using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.ExchangeRate;

namespace Currencies.Contracts.Interfaces;

public interface IExchangeRateService
{
    Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(CancellationToken cancellationToken);
    Task<ExchangeRateDto> GetExchangeRateByIdAsync(int exchangeRateId, CancellationToken cancellationToken);
    Task<ExchangeRateDto> CreateExchangeRateAsync(BaseExchangeRateDto dto, CancellationToken cancellationToken);
    Task<ExchangeRateDto> UpdateExchangeRateAsync(int exchangeRateId, BaseExchangeRateDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteExchangeRateAsync(int exchangeRateId, CancellationToken cancellationToken);
}