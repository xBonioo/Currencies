using MediatR;

using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;

namespace Currencies.Api.Functions.UserExchangeHistory.Queries.GetAll;

public class GetUserExchangeHistoryListQuery : IRequest<PageResult<UserExchangeHistoryDto>>
{
    public FilterUserExchangeHistoryDto Filter;

    public GetUserExchangeHistoryListQuery(FilterUserExchangeHistoryDto filter)
    {
        Filter = filter;
    }
}
