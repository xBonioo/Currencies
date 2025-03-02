using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.Role.Queries.GetAll;

public class GetRolesListQuery : IRequest<PageResult<RoleDto>>
{
    public FilterRoleDto Filter;

    public GetRolesListQuery(FilterRoleDto filter)
    {
        Filter = filter;
    }
}