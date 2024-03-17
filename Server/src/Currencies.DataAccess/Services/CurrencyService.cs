using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
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

        var currency = _mapper.Map<Currency>(dto);
        _dbContext.Currencies.Add(currency);

        if (await _dbContext.SaveChangesAsync() > 0)
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
            return false;
        }

        currency.IsActive = false;

        if ((await _dbContext.SaveChangesAsync()) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(DeleteAsync)}");
    }

    public async Task<PageResult<CurrencyDto>> GetAllCurrenciesAsync(FilterCurrencyDto filter, CancellationToken cancellationToken)
    {
        var baseQuery = _dbContext
            .Currencies
            .AsQueryable()
            .Where(x => x.IsActive == true);

        if (!baseQuery.Any())
        {
            return null;
        }

        if (!string.IsNullOrEmpty(filter.SearchPhrase))
        {
            baseQuery = baseQuery.Where(x => x.Name.Contains(filter.SearchPhrase) || x.Symbol.Contains(filter.SearchPhrase) || x.Description!.Contains(filter.SearchPhrase));
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
            return null;
        }

        currency.Name = dto.Name;
        currency.Symbol = dto.Symbol;
        currency.Description = dto.Description;
        currency.IsActive = dto.IsActive;

        if ((await _dbContext.SaveChangesAsync()) > 0)
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