using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Functions.Currency.Queries.GetAll;

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