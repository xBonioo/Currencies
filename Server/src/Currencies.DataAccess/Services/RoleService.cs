using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Models;

namespace Currencies.DataAccess.Services;

public class RoleService : IRoleService
{
    private readonly TableContext _dbContext;

    public RoleService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto roleDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PageResult<RoleDto>> GetAllCurrenciesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<RoleDto> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<RoleDto> UpdateRoleAsync(int roleId, UpdateRoleDto updateRoleDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}