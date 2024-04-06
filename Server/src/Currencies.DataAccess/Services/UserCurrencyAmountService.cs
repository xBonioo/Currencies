using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Models;
using Currencies.Models.Entities;

namespace Currencies.DataAccess.Services;

public class UserCurrencyAmountService : IUserCurrencyAmountService
{
    private readonly TableContext _dbContext;

    public UserCurrencyAmountService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserCurrencyAmountDto?> ConvertAsync(ConvertUserCurrencyAmountDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<UserCurrencyAmountDto>> GetAllUserCurrencyAmountsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCurrencyAmountDto> AddAsync(int id, BaseUserCurrencyAmountDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCurrencyAmountDto> UpdateAsync(int id, BaseUserCurrencyAmountDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserCurrencyAmount?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}