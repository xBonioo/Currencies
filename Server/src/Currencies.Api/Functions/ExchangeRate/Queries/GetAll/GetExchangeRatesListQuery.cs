using MediatR;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.Response;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetAll;

public class GetExchangeRatesListQuery : IRequest<PageResult<ExchangeRateDto>>
{
    public FilterExchangeRateDto Filter;

    public GetExchangeRatesListQuery(FilterExchangeRateDto filter)
    {
        Filter = filter;
    }
}