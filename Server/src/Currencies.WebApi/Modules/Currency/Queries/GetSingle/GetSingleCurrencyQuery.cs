using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Modules.Currency.Queries.GetSingle;

public record GetSingleCurrencyQuery(int id) : IRequest<CurrencyDto>;