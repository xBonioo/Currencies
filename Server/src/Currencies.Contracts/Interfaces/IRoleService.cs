using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Models.Entities;

namespace Currencies.Contracts.Interfaces;

public interface IRoleService : IEntityService<Role>
{
    Task<PageResult<RoleDto>> GetAllRolesAsync(FilterRoleDto filter, CancellationToken cancellationToken);
    Task<RoleDto?> CreateAsync(BaseRoleDto dto, CancellationToken cancellationToken);
    Task<RoleDto?> UpdateAsync(int id, BaseRoleDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}