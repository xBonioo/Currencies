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

    public async Task<bool> CreateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRoleAsync(int roleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RoleDto>> GetAllCurrenciesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<RoleDto> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRoleAsync(int roleId, RoleDto roleDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}