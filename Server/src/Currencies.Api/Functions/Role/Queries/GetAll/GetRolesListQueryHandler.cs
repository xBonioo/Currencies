using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.Role.Queries.GetAll;

public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, PageResult<RoleDto>?>
{
    private readonly IRoleService _roleService;

    public GetRoleListQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<PageResult<RoleDto>?> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        return await _roleService.GetAllRolesAsync(request.Filter, cancellationToken);
    }
}