using Currencies.Contracts.ModelDtos.Account;
using Currencies.Contracts.ModelDtos.User;

namespace Currencies.Contracts.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserExchangeHistoryDto>> GetUserExchangeHistoryAsync(string userId);
    Task AddUserExchangeHistoryAsync(UserExchangeHistoryDto history);
}
