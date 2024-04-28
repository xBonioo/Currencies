using MediatR;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Role;

namespace Currencies.Api.Functions.Role.Queries.GetAll;

public class GetRoleListQuery : IRequest<PageResult<RoleDto>>
{
    public FilterRoleDto Filter;

    public GetRoleListQuery(FilterRoleDto filter)
    {
        Filter = filter;
    }
}