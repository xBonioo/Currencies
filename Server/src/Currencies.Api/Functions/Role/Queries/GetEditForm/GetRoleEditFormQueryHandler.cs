using AutoMapper;
using Currencies.Api.Functions.Role.Queries.GetEditForm;
using Currencies.Contracts.Helpers.Controls;
using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Interfaces;
using Currencies.DataAccess.Services;
using Currencies.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Currencies.Api.Functions.Role.Queries.GetEditForm;

public class GetRoleEditFormQueryHandler : IRequestHandler<GetRoleEditFormQuery, RoleEditForm?>
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;
    private readonly TableContext _dbContext;

    public GetRoleEditFormQueryHandler(IRoleService roleService, IMapper mapper, TableContext dbContext)
    {
        _roleService = roleService;
        _mapper = mapper;
        _dbContext = dbContext;
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