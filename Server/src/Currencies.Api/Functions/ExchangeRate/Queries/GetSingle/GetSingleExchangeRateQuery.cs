using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetSingle;

public record GetSingleExchangeRateQuery(int id) : IRequest<ExchangeRateDto>;