using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.Currency.Queries.GetAll;

public class GetCurrenciesListQuery : IRequest<PageResult<CurrencyDto>>
{
    public FilterCurrencyDto Filter;

    public GetCurrenciesListQuery(FilterCurrencyDto filter)
    {
        Filter = filter;
    }
}