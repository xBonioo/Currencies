using Currencies.Contracts.ModelDtos.ExchangeRate;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetSingle;

public record GetSingleExchangeRateQuery(int id) : IRequest<ExchangeRateDto>;