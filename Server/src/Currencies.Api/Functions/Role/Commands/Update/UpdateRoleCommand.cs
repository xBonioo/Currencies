using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.Role.Commands.Update;

public class UpdateRoleCommand : IRequest<RoleDto>
{
    public int Id { get; set; }
    public BaseRoleDto Dto { get; set; }

    public UpdateRoleCommand(int id, BaseRoleDto dto)
    {
        Id = id;
        Dto = dto;
    }
}