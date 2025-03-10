﻿using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.ExchangeRate.Queries.GetAll;

public class GetExchangeRatesListQueryHandler : IRequestHandler<GetExchangeRatesListQuery, PageResult<ExchangeRateDto>?>
{
    private readonly IExchangeRateService _exchangeRateService;

    public GetExchangeRatesListQueryHandler(IExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    public async Task<PageResult<ExchangeRateDto>?> Handle(GetExchangeRatesListQuery request, CancellationToken cancellationToken)
    {
        return await _exchangeRateService.GetAllExchangeRateAsync(request.Filter, cancellationToken);
    }
}