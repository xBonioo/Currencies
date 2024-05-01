using MediatR;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.ModelDtos.ExchangeRate;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetAll;

public class GetExchangeRatesListQuery : IRequest<PageResult<ExchangeRateDto>>
{
    public FilterExchangeRateDto Filter;

    public GetExchangeRatesListQuery(FilterExchangeRateDto filter)
    {
        Filter = filter;
    }
}