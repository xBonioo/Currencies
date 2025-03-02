using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Contracts.Helpers.Exceptions;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Contracts.Response;
using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DataAccess.Services;

public class UserExchangeHistoryService(TableContext dbContext, IMapper mapper) : IUserExchangeHistoryService
{
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

        dbContext.UserExchangeHistories.Add(history);

        if (await dbContext.SaveChangesAsync(cancellationToken) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(AddUserExchangeHistoryAsync)}");
    }

    public async Task<PageResult<UserExchangeHistoryDto>> GetAllUserExchangeHistoryServiceiesAsync(FilterUserExchangeHistoryDto filter, CancellationToken cancellationToken)
    {
        var baseQuery = dbContext
         .UserExchangeHistories
         .AsQueryable();

        if (!baseQuery.Any())
        {
            throw new NotFoundException("User exchange history not found");
        }

        if (!string.IsNullOrEmpty(filter.SearchPhrase))
        {
            baseQuery = baseQuery.Where(x => x.UserID.Contains(filter.SearchPhrase));
        }

        var totalItemCount = baseQuery.Count();

        var itemsDto = await baseQuery
            .Skip(filter.PageSize * (filter.PageNumber - 1))
            .Take(filter.PageSize)
            .ProjectTo<UserExchangeHistoryDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PageResult<UserExchangeHistoryDto>(itemsDto, totalItemCount, filter.PageSize, filter.PageNumber);
    }

    public async Task<UserExchangeHistory?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await dbContext
           .UserExchangeHistories
           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return result;
    }
}