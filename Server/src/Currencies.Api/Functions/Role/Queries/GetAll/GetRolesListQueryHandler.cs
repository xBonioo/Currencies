using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Functions.Role.Queries.GetAll;

public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, PageResult<RoleDto>?>
{
    private readonly IRoleService _roleService;

    public GetRolesListQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<PageResult<RoleDto>?> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        return await _roleService.GetAllRolesAsync(request.Filter, cancellationToken);
    }
}