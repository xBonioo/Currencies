using MediatR;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;

namespace Currencies.Api.Functions.UserCurrencyAmount.Queries.GetAll;

public class GetUserCurrencyAmountsListQuery : IRequest<PageResult<UserCurrencyAmountDto>>
{
    public FilterUserCurrencyAmountDto Filter;

    public GetUserCurrencyAmountsListQuery(FilterUserCurrencyAmountDto filter)
    {
        Filter = filter;
    }
}
