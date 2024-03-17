using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Models;
using Currencies.Models.Entities;

namespace Currencies.DataAccess.Services;

public class UserExchangeHistoryService : IUserExchangeHistoryService
{
    private readonly TableContext _dbContext;

    public UserExchangeHistoryService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddUserExchangeHistoryAsync(UserExchangeHistoryDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<UserExchangeHistoryDto>> GetAllUserExchangeHistoryServiceiesAsync(FilterRoleDto filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserExchangeHistory?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}