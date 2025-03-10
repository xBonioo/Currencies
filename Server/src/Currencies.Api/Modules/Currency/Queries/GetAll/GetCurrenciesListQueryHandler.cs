﻿using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.Currency.Queries.GetAll;

public class GetCurrenciesListQueryHandler : IRequestHandler<GetCurrenciesListQuery, PageResult<CurrencyDto>?>
{
    private readonly ICurrencyService _currencyService;

    public GetCurrenciesListQueryHandler(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    public async Task<PageResult<CurrencyDto>?> Handle(GetCurrenciesListQuery request, CancellationToken cancellationToken)
    {
        return await _currencyService.GetAllCurrenciesAsync(request.Filter, cancellationToken);
    }
}