using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Models;

namespace Currencies.DataAccess.Services;

public class UserCurrencyAmountService : IUserCurrencyAmountService
{
    private readonly TableContext _dbContext;

    public UserCurrencyAmountService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserCurrencyAmountDto> ConvertCurrencyAsync(ConvertUserCurrencyAmountDto convertUserCurrencyAmountDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUserCurrencyAmountAsync(int userCurrencyAmountId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<UserCurrencyAmountDto>> GetAllUserCurrencyAmountsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCurrencyAmountDto> GetUserCurrencyAmountByIdAsync(int userCurrencyAmountId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCurrencyAmountDto> AddUserCurrencyAmountAsync(int userCurrencyAmountId, UpdateUserCurrencyAmountDto userCurrencyAmountDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCurrencyAmountDto> UpdateUserCurrencyAmountAsync(int userCurrencyAmountId, UpdateUserCurrencyAmountDto userCurrencyAmountDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}