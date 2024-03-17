using MediatR;

using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Currency;

namespace Currencies.Api.Functions.Currency.Queries.GetAll;

public class GetCurrenciesListQuery : IRequest<PageResult<CurrencyDto>>
{
    public FilterCurrencyDto Filter;

    public GetCurrenciesListQuery(FilterCurrencyDto filter)
    {
        Filter = filter;
    }
}