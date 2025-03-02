using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Queries.GetAll;

public class GetUserCurrencyAmountsListQuery : IRequest<PageResult<UserCurrencyAmountDto>>
{
    public FilterUserCurrencyAmountDto Filter;

    public GetUserCurrencyAmountsListQuery(FilterUserCurrencyAmountDto filter)
    {
        Filter = filter;
    }
}
