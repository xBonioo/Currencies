using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DataAccess.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly TableContext _dbContext;
    private readonly IMapper _mapper;

    public ExchangeRateService(TableContext dbContext,
                               IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ExchangeRateDto?> CreateAsync(BaseExchangeRateDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
        {
            return null;
        }

        var exchangeRate = new ExchangeRate()
        {
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow,
            Rate = dto.Rate,
            FromCurrencyID = dto.FromCurrencyId,
            ToCurrencyID= dto.ToCurrencyId,
            Direction = dto.Direction
        };

        _dbContext.ExchangeRate.Add(exchangeRate);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return _mapper.Map<ExchangeRateDto>(exchangeRate);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(CreateAsync)}");
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var exchangeRate = await GetByIdAsync(id, cancellationToken);
        if (exchangeRate == null)
        {
            return false;
        }

        exchangeRate.IsActive = false;

        if ((await _dbContext.SaveChangesAsync()) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(DeleteAsync)}");
    }

    public async Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(FilterDto filter,CancellationToken cancellationToken)
    {
        var baseQuery = _dbContext
            .ExchangeRate
            .AsQueryable();

        var totalItemCount = baseQuery.Count();

        var itemsDto = await baseQuery
            .Skip(filter.PageSize * (filter.PageNumber - 1))
            .Take(filter.PageSize)
            .ProjectTo<ExchangeRateDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PageResult<ExchangeRateDto>(itemsDto, totalItemCount, filter.PageSize, filter.PageNumber);
    }

    public async Task<ExchangeRateDto?> UpdateAsync(int id, BaseExchangeRateDto dto, CancellationToken cancellationToken)
    {
        var exchangeRate = await GetByIdAsync(id, cancellationToken);
        if (exchangeRate == null)
        {
            return null;
        }

        exchangeRate.FromCurrencyID = dto.FromCurrencyId;
        exchangeRate.ToCurrencyID = dto.ToCurrencyId;
        exchangeRate.Rate = dto.Rate;
        exchangeRate.Direction = dto.Direction;

        if ((await _dbContext.SaveChangesAsync()) > 0)
        {
            return _mapper.Map<ExchangeRateDto>(exchangeRate);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(UpdateAsync)}");
    }

    public async Task<ExchangeRate?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
       return await _dbContext
                        .ExchangeRate
                        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}