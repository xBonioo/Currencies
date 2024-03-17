using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Models;

namespace Currencies.DataAccess.Services;

public class UserExchangeHistoryService : IUserExchangeHistoryService
{
    private readonly TableContext _dbContext;

    public UserExchangeHistoryService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddUserExchangeHistoryAsync(UserExchangeHistoryDto history, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<UserExchangeHistoryDto>> GetAllUserExchangeHistoryServiceiesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserExchangeHistoryDto> GetUserExchangeHistoryByIdAsync(int userCurrencyAmountId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}