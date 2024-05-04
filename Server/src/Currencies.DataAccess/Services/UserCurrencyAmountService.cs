using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;

using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DataAccess.Services;

public class UserCurrencyAmountService : IUserCurrencyAmountService
{
    private readonly TableContext _dbContext;
    private readonly IMapper _mapper;

    public UserCurrencyAmountService(TableContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserCurrencyAmountDto?> ConvertAsync(ConvertUserCurrencyAmountDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var user_currency_amount = await GetByIdAsync(id, cancellationToken);
        if (user_currency_amount == null || !user_currency_amount.IsActive)
        {
            return false;
        }

        user_currency_amount.IsActive = false;

        if ((await _dbContext.SaveChangesAsync()) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(DeleteAsync)}");
    }

    public async Task<PageResult<UserCurrencyAmountDto>> GetAllUserCurrencyAmountsAsync(FilterUserCurrencyAmountDto filter, CancellationToken cancellationToken)
    {
        var baseQuery = _dbContext
          .UserCurrencyAmounts
          .AsQueryable();

        if (!baseQuery.Any())
        {
            return null;
        }

        if (!string.IsNullOrEmpty(filter.SearchPhrase))
        {
            baseQuery = baseQuery.Where(x => x.UserId.Contains(filter.SearchPhrase));
        }
        if (filter.IsActive != null)
        {
            baseQuery = baseQuery.Where(x => x.IsActive == filter.IsActive);
        }

        var totalItemCount = baseQuery.Count();

        var itemsDto = await baseQuery
            .Skip(filter.PageSize * (filter.PageNumber - 1))
            .Take(filter.PageSize)
            .ProjectTo<UserCurrencyAmountDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PageResult<UserCurrencyAmountDto>(itemsDto, totalItemCount, filter.PageSize, filter.PageNumber);
    }

    public async Task<UserCurrencyAmountDto> AddAsync(int id, BaseUserCurrencyAmountDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
        {
            return null;
        }

        var user_currency_amount = new UserCurrencyAmount()
        {
            UserId = dto.UserId,
            CurrencyId = dto.CurrencyId,
            Amount = dto.Amount,
            IsActive = true
        };

        _dbContext.UserCurrencyAmounts.Add(user_currency_amount);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return _mapper.Map<UserCurrencyAmountDto>(user_currency_amount);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(AddAsync)}");
    }

    public async Task<UserCurrencyAmountDto> UpdateAsync(int id, BaseUserCurrencyAmountDto dto, CancellationToken cancellationToken)
    {
        var user_currency_amount = await GetByIdAsync(id, cancellationToken);
        if (user_currency_amount == null || !user_currency_amount.IsActive)
        {
            return null;
        }

        user_currency_amount.UserId = dto.UserId;
        user_currency_amount.CurrencyId = dto.CurrencyId;
        user_currency_amount.Amount = dto.Amount;
        user_currency_amount.IsActive = dto.IsActive;

        if ((await _dbContext.SaveChangesAsync()) > 0)
        {
            return _mapper.Map<UserCurrencyAmountDto>(user_currency_amount);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(UpdateAsync)}");
    }

    public async Task<UserCurrencyAmount?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext
           .UserCurrencyAmounts
           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return result;
    }
}