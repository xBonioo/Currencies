using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Models;
using Currencies.Models.Entities;

namespace Currencies.DataAccess.Services;

public class RoleService : IRoleService
{
    private readonly TableContext _dbContext;

    public RoleService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RoleDto?> CreateAsync(BaseRoleDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<RoleDto>> GetAllRolesAsync(FilterRoleDto filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<RoleDto?> UpdateAsync(int id, BaseRoleDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Role?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}