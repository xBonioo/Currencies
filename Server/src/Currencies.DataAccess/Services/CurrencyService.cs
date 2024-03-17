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

    public async Task<CurrencyDto?> CreateCurrencyAsync(BaseCurrencyDto createCurrencyDto, CancellationToken cancellationToken)
    {
        if (createCurrencyDto == null)
        {
            return null;
        }

        var currency = _mapper.Map<Currency>(createCurrencyDto);

        _dbContext.Currencies.Add(currency);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return _mapper.Map<CurrencyDto>(currency);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(CreateCurrencyAsync)}");
    }

    public async Task<bool> DeleteCurrencyAsync(int currencyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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

    public async Task<CurrencyDto?> GetCurrencyByIdAsync(int currencyId, CancellationToken cancellationToken)
    {
        var result = await _dbContext
            .Currencies
            .FirstOrDefaultAsync(x => x.Id == currencyId);

        return _mapper.Map<CurrencyDto>(result);
    }

    public async Task<CurrencyDto> UpdateCurrencyAsync(int currencyId, BaseCurrencyDto updateCurrencyDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}