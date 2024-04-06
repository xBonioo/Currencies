using Currencies.Contracts.Interfaces;
using MediatR;

namespace Currencies.Api.Functions.Role.Commands.Delete;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.DeleteAsync(request.Id, cancellationToken);
    }
}