using MediatR;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Contracts.Response;

namespace Currencies.Api.Functions.UserExchangeHistory.Queries.GetAll;

public class GetUserExchangeHistoryListQuery : IRequest<PageResult<UserExchangeHistoryDto>>
{
    public FilterUserExchangeHistoryDto Filter;

    public GetUserExchangeHistoryListQuery(FilterUserExchangeHistoryDto filter)
    {
        Filter = filter;
    }
}
