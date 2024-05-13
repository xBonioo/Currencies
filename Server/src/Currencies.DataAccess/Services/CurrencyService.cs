using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Contracts.Helpers.Exceptions;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.Response;
using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
        var baseQuery = _dbContext
            .Currencies
            .AsQueryable();

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

        var itemsDto = await baseQuery
            .Skip(filter.PageSize * (filter.PageNumber - 1))
            .Take(filter.PageSize)
            .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

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