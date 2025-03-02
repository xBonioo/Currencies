using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Queries.GetSingle;

public record GetSingleUserCurrencyAmountQuery(string Id) : IRequest<List<UserCurrencyAmountDto>>;
