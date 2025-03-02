using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.UserExchangeHistory.Queries.GetAll;

public class GetUserExchangeHistoryListQuery : IRequest<PageResult<UserExchangeHistoryDto>>
{
    public FilterUserExchangeHistoryDto Filter;

    public GetUserExchangeHistoryListQuery(FilterUserExchangeHistoryDto filter)
    {
        Filter = filter;
    }
}
