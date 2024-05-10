using MediatR;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.Response;

namespace Currencies.Api.Functions.Currency.Queries.GetAll;

public class GetCurrenciesListQuery : IRequest<PageResult<CurrencyDto>>
{
    public FilterCurrencyDto Filter;

    public GetCurrenciesListQuery(FilterCurrencyDto filter)
    {
        Filter = filter;
    }
}