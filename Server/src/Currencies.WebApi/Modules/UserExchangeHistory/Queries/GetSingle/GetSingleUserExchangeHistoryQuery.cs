using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using MediatR;

namespace Currencies.Api.Modules.UserExchangeHistory.Queries.GetSingle;

public record GetSingleUserExchangeHistoryQuery(int Id) : IRequest<UserExchangeHistoryDto>;
