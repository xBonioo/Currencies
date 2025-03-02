using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.ExchangeRate.Queries.GetAll;

public class GetExchangeRatesListQuery : IRequest<PageResult<ExchangeRateDto>>
{
    public FilterExchangeRateDto Filter;

    public GetExchangeRatesListQuery(FilterExchangeRateDto filter)
    {
        Filter = filter;
    }
}