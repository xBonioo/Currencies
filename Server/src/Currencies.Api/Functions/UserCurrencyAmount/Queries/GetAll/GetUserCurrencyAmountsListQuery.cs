using MediatR;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Contracts.Response;

namespace Currencies.Api.Functions.UserCurrencyAmount.Queries.GetAll;

public class GetUserCurrencyAmountsListQuery : IRequest<PageResult<UserCurrencyAmountDto>>
{
    public FilterUserCurrencyAmountDto Filter;

    public GetUserCurrencyAmountsListQuery(FilterUserCurrencyAmountDto filter)
    {
        Filter = filter;
    }
}
