using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Modules.Role.Commands.Update;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleDto>
{
    private readonly IRoleService _roleService;

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<RoleDto?> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.UpdateAsync(request.Id, request.Dto, cancellationToken);
    }
}