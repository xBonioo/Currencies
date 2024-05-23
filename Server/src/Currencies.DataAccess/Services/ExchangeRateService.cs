﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Common.Enum;
using Currencies.Contracts.Helpers.Exceptions;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.Response;
using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DataAccess.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly TableContext _dbContext;
    private readonly IMapper _mapper;

    public ExchangeRateService(TableContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ExchangeRateDto?>> CreateAsync(List<CurrencyExchangeRateDto> currencyExchangeRateList, CancellationToken cancellationToken)
    {
        if (currencyExchangeRateList == null || !currencyExchangeRateList.Any())
        {
            throw new NotFoundException("Exchange rates not found");
        }

        var currencies = await _dbContext.Currencies
            .AsQueryable()
            .ToListAsync(cancellationToken);

        var result = new List<ExchangeRate>();
        foreach (var item in currencyExchangeRateList)
        {
            var buyRate = new ExchangeRate
            {
                Rate = item.Ask,
                FromCurrencyID = 4,
                ToCurrencyID = currencies.FirstOrDefault(x => x.Symbol.Contains(item.Code))!.Id,
                Direction = Direction.Buy
            };
            result.Add(buyRate);

            var sellRate = new ExchangeRate
            {
                Rate = item.Bid,
                FromCurrencyID = 4,
                ToCurrencyID = currencies.FirstOrDefault(x => x.Symbol.Contains(item.Code))!.Id,
                Direction = Direction.Sell
            };
            result.Add(sellRate);
        }

        if (!result.Any())
        {
            throw new NotFoundException("Exchange rates not found");
        }

        await _dbContext.AddRangeAsync(result, cancellationToken);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
        {
            return _mapper.Map<List<ExchangeRateDto?>>(result);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(CreateAsync)}");
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var exchangeRate = await GetByIdAsync(id, cancellationToken);
        if (exchangeRate == null)
        {
            throw new NotFoundException("Exchange rate not found");
        }

        exchangeRate.IsActive = false;

        if ((await _dbContext.SaveChangesAsync(cancellationToken)) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(DeleteAsync)}");
    }

    public async Task<PageResult<ExchangeRateDto>> GetAllExchangeRateAsync(FilterExchangeRateDto filter,CancellationToken cancellationToken)
    {
        var baseQuery = _dbContext
            .ExchangeRate
            .AsQueryable()
            .Include(x => x.FromCurrency)
            .Include(x => x.ToCurrency);

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
            throw new NotFoundException("Exchange rate not found");
        }

        exchangeRate.FromCurrencyID = dto.FromCurrencyId;
        exchangeRate.ToCurrencyID = dto.ToCurrencyId;
        exchangeRate.Rate = dto.Rate;
        exchangeRate.Direction = dto.Direction;
        exchangeRate.IsActive = dto.IsActive;

        if ((await _dbContext.SaveChangesAsync(cancellationToken)) > 0)
        {
            return _mapper.Map<ExchangeRateDto>(exchangeRate);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(UpdateAsync)}");
    }

    public async Task<ExchangeRate?> GetByIdFromCurrencyAsync(int fromId, int toId, CancellationToken cancellationToken)
    {
        var exchangeRate = await _dbContext
                            .ExchangeRate
                            .AsQueryable()
                            .Include(x => x.FromCurrency)
                            .Include(x => x.ToCurrency)
                            .Where(x => x.FromCurrencyID == fromId && x.ToCurrencyID == toId)
                            .OrderByDescending(x => x.CreatedOn)
                            .FirstOrDefaultAsync(cancellationToken);

        if (exchangeRate == null)
        {
            throw new NotFoundException("Exchange rate not found");
        }

        return exchangeRate;
    }

    public async Task<ExchangeRate?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
       return await _dbContext
                    .ExchangeRate
                    .AsQueryable()
                    .Include(x => x.FromCurrency)
                    .Include(x => x.ToCurrency)
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}