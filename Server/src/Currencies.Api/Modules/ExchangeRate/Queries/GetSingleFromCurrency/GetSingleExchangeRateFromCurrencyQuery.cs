using Currencies.Contracts.ModelDtos.ExchangeRate;
using MediatR;

namespace Currencies.Api.Modules.ExchangeRate.Queries.GetSingleFromCurrency;

public record GetSingleExchangeRateFromCurrencyQuery(int fromId, int toId) : IRequest<(ExchangeRateDto?, ExchangeRateDto?)>;