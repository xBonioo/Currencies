using Currencies.Contracts.ModelDtos.ExchangeRate;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetSingleFromCurrency;

public record GetSingleExchangeRateFromCurrencyQuery(int fromId, int toId) : IRequest<(ExchangeRateDto?, ExchangeRateDto?)>;