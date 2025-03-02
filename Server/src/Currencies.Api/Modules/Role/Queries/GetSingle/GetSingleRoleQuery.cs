using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Modules.Role.Queries.GetSingle;

public record GetSingleRoleQuery(int id) : IRequest<RoleDto>;