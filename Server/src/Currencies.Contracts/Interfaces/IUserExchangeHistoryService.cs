using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Models.Entities;

namespace Currencies.Contracts.Interfaces;

public interface IUserExchangeHistoryService : IEntityService<UserExchangeHistory>
{
    Task<PageResult<UserExchangeHistoryDto>> GetAllUserExchangeHistoryServiceiesAsync(FilterUserExchangeHistoryDto filter, CancellationToken cancellationToken);
    Task<bool> AddUserExchangeHistoryAsync(UserExchangeHistoryDto dto, CancellationToken cancellationToken);
}