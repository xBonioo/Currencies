using MediatR;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Role;

namespace Currencies.Api.Functions.Role.Queries.GetAll;

public class GetExchangeRateListQuery : IRequest<PageResult<RoleDto>>
{
    public FilterRoleDto Filter;

    public GetExchangeRateListQuery(FilterRoleDto filter)
    {
        Filter = filter;
    }
}