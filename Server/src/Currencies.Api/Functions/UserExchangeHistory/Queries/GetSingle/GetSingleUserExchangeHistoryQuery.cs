using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using MediatR;

namespace Currencies.Api.Functions.UserExchangeHistory.Queries.GetSingle;

public record GetSingleUserExchangeHistoryQuery(int Id) : IRequest<UserExchangeHistoryDto>;
