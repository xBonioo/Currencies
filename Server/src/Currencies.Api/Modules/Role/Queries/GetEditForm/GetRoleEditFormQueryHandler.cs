using Currencies.Contracts.Helpers.Controls;
using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Interfaces;
using MediatR;

namespace Currencies.Api.Modules.Role.Queries.GetEditForm;

public class GetRoleEditFormQueryHandler : IRequestHandler<GetRoleEditFormQuery, RoleEditForm?>
{
    private readonly IRoleService _roleService;

    public GetRoleEditFormQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<RoleEditForm> Handle(GetRoleEditFormQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleService.GetByIdAsync(request.id, cancellationToken);
        if (role == null || !role.IsActive)
        {
            var createForm = new RoleEditForm()
            {
                Name = new StringControl()
                {
                    IsRequired = true,
                    Value = string.Empty,
                    MinLenght = 1,
                    MaxLenght = 64
                },
                IsActive = new BoolControl()
                {
                    IsRequired = true,
                    Value = true
                }
            };

            return createForm;
        }

        var editForm = new RoleEditForm()
        {
            Name = new StringControl()
            {
                IsRequired = true,
                Value = role.Name,
                MinLenght = 1,
                MaxLenght = 64
            },
            IsActive = new BoolControl()
            {
                IsRequired = true,
                Value = role.IsActive
            }
        };

        return editForm;
    }
}