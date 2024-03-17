using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Functions.Currency.Queries.GetSingle;

public record GetSingleCurrencyQuery(int id) : IRequest<CurrencyDto>;