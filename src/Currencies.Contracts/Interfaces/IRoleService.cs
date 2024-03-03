using Currencies.Contracts.ModelDtos.Role;

namespace Currencies.Contracts.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllCurrenciesAsync(CancellationToken cancellationToken);
    Task<RoleDto> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken);
    Task<bool> CreateRoleAsync(RoleDto roleDto, CancellationToken cancellationToken);
    Task UpdateRoleAsync(int roleId, RoleDto roleDto, CancellationToken cancellationToken);
    Task DeleteRoleAsync(int roleId, CancellationToken cancellationToken);
}