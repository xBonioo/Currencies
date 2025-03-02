using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Modules.Role.Commands.Create;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleDto?>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<RoleDto?> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.CreateAsync(request.Data, cancellationToken);
    }
}