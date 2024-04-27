using MediatR;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.ModelDtos.ExchangeRate;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetAll;

public class GetExchangeRateListQuery : IRequest<PageResult<ExchangeRateDto>>
{
    public FilterExchangeRateDto Filter;

    public GetExchangeRateListQuery(FilterExchangeRateDto filter)
    {
        Filter = filter;
    }
}