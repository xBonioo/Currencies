using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Queries.GetSingle;

public record GetSingleUserCurrencyAmountQuery(int Id) : IRequest<UserCurrencyAmountDto>;
