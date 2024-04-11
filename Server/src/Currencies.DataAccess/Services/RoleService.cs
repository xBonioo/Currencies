using AutoMapper;
using AutoMapper.QueryableExtensions;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Models;
using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Currencies.DataAccess.Services;

public class RoleService : IRoleService
{
    private readonly TableContext _dbContext;
    private readonly IMapper _mapper;

    public RoleService(TableContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<RoleDto?> CreateAsync(BaseRoleDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
        {
            return null;
        }

        var role = new Role()
        {
            Name = dto.Name        
        };

        _dbContext.Roles.Add(role);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return _mapper.Map<RoleDto>(role);
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(CreateAsync)}");

    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var role = await GetByIdAsync(id, cancellationToken);
        if (role == null || !role.IsActive)
        {
            return false;
        }

        role.IsActive = false;

        if ((await _dbContext.SaveChangesAsync()) > 0)
        {
            return true;
        }

        throw new DbUpdateException($"Could not save changes to database at: {nameof(DeleteAsync)}");
    }

    public async Task<PageResult<RoleDto>?> GetAllRolesAsync(FilterRoleDto filter, CancellationToken cancellationToken)
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