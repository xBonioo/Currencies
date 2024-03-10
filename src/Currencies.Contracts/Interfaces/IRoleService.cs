using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Role;

namespace Currencies.Contracts.Interfaces;

public interface IRoleService
{
    Task<PageResult<RoleDto>> GetAllCurrenciesAsync(CancellationToken cancellationToken);
    Task<RoleDto> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken);
    Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto, CancellationToken cancellationToken);
    Task<RoleDto> UpdateRoleAsync(int roleId, UpdateRoleDto updateRoleDto, CancellationToken cancellationToken);
    Task<bool> DeleteRoleAsync(int roleId, CancellationToken cancellationToken);
}