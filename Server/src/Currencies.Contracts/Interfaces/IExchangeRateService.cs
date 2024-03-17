using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.ExchangeRate;

namespace Currencies.Contracts.Interfaces;

public interface IExchangeRateService
{
    Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(CancellationToken cancellationToken);
    Task<ExchangeRateDto> GetExchangeRateByIdAsync(int currencyId, CancellationToken cancellationToken);
    Task<ExchangeRateDto> CreateExchangeRateAsync(BaseExchangeRateDto createExchangeRateDto, CancellationToken cancellationToken);
    Task<ExchangeRateDto> UpdateExchangeRateAsync(int exchangeRateId, BaseExchangeRateDto updateExchangeRateDto, CancellationToken cancellationToken);
    Task<bool> DeleteExchangeRateAsync(int exchangeRateId, CancellationToken cancellationToken);
}