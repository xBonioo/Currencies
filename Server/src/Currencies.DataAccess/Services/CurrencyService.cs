using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Common.Enum;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.Helpers.Exceptions;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.Response;
using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Currencies.DataAccess.Services;

public class CurrencyService : ICurrencyService
{
    private readonly TableContext _dbContext;
    private readonly IMapper _mapper;

    public CurrencyService(TableContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CurrencyDto?> CreateAsync(BaseCurrencyDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
        {
            return null;
        }

        var currency = new Currency()
        {
            Name = dto.Name,
            Symbol = dto.Symbol,
            Description = dto.Description
        };

        _dbContext.Currencies.Add(currency);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
        {
            return _mapper.Map<CurrencyDto>(currency);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(CreateAsync)}");
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var currency = await GetByIdAsync(id, cancellationToken);
        if (currency == null || !currency.IsActive)
        {
            throw new NotFoundException("Currencies not found");
        }

        currency.IsActive = false;

        if ((await _dbContext.SaveChangesAsync(cancellationToken)) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(DeleteAsync)}");
    }

    public async Task<PageResult<CurrencyDto>?> GetAllCurrenciesAsync(FilterCurrencyDto filter, CancellationToken cancellationToken)
    {
        var baseQuery = from c in _dbContext.Currencies
                    join er0 in _dbContext.ExchangeRate.Where(er => er.Direction == Direction.Buy && er.IsActive)
                        on c.Id equals er0.ToCurrencyID into er0Group
                    from er0 in er0Group.DefaultIfEmpty()
                    join er1 in _dbContext.ExchangeRate.Where(er => er.Direction == Direction.Sell && er.IsActive)
                        on c.Id equals er1.ToCurrencyID into er1Group
                    from er1 in er1Group.DefaultIfEmpty()
                    where c.IsActive
                    select new AnonymousTypeModel
                    {
                        Name = c.Name,
                        Symbol = c.Symbol,
                        Description = c.Description,
                        Rate_Direction_0 = er0 != null ? er0.Rate : (decimal?)null,
                        Rate_Direction_1 = er1 != null ? er1.Rate : (decimal?)null,
                        IsActive = c.IsActive
                    };


        if (!baseQuery.Any())
        {
            throw new NotFoundException("Currency not found");
        }

        if (!string.IsNullOrEmpty(filter.SearchPhrase))
        {
            baseQuery = baseQuery.Where(x => x.Name.Contains(filter.SearchPhrase) || x.Symbol.Contains(filter.SearchPhrase) || (!string.IsNullOrEmpty(x.Description) && x.Description.Contains(filter.SearchPhrase)));
        }
        if (filter.IsActive != null)
        {
            baseQuery = baseQuery.Where(x => x.IsActive == filter.IsActive);
        }

        var totalItemCount = baseQuery.Count();

        var itemsDto = baseQuery
            .Skip(filter.PageSize * (filter.PageNumber - 1))
            .Take(filter.PageSize)
            .AsEnumerable()
            .Select(x => _mapper.Map<CurrencyDto>(x))
            .ToList();

        return new PageResult<CurrencyDto>(itemsDto, totalItemCount, filter.PageSize, filter.PageNumber);
    }

    public async Task<CurrencyDto?> UpdateAsync(int id, BaseCurrencyDto dto, CancellationToken cancellationToken)
    {
        var currency = await GetByIdAsync(id, cancellationToken);
        if (currency == null || !currency.IsActive)
        {
            throw new NotFoundException("Currency not found");
        }

        currency.Name = dto.Name;
        currency.Symbol = dto.Symbol;
        currency.Description = dto.Description;
        currency.IsActive = dto.IsActive;

        if ((await _dbContext.SaveChangesAsync(cancellationToken)) > 0)
        {
            return _mapper.Map<CurrencyDto>(currency);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(UpdateAsync)}");
    }

    public async Task<Currency?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext
            .Currencies
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return result;
    }
}