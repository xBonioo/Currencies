using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Contracts.Response;
using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
        if (dto == null)
        {
            return false;
        }

        var history = new UserExchangeHistory()
        {
            UserID = dto.UserID,
            RateID = dto.RateID,
            Amount = dto.Amount,
            AccountID = dto.AccountID,
            PaymentStatus = dto.PaymentStatus,
            PaymentType = dto.PaymentType,
        };

        _dbContext.UserExchangeHistories.Add(history);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(AddUserExchangeHistoryAsync)}");
    }

    public async Task<PageResult<UserExchangeHistoryDto>> GetAllUserExchangeHistoryServiceiesAsync(FilterUserExchangeHistoryDto filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserExchangeHistory?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}