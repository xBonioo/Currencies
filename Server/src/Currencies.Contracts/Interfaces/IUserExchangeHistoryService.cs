using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;

namespace Currencies.Contracts.Interfaces;

public interface IUserExchangeHistoryService
{
    Task<PageResult<UserExchangeHistoryDto>> GetAllUserExchangeHistoryServiceiesAsync(CancellationToken cancellationToken);
    Task<UserExchangeHistoryDto> GetUserExchangeHistoryByIdAsync(int userCurrencyAmountId, CancellationToken cancellationToken);
}