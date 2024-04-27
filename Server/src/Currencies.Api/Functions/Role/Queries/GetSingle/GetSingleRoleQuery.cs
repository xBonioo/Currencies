using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.Role.Queries.GetSingle;

public record GetSingleExchangeRateQuery(int id) : IRequest<RoleDto>;