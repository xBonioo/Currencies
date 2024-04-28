using MediatR;

namespace Currencies.Api.Functions.Role.Commands.Delete;

public class DeleteRoleCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteRoleCommand(int id)
    {
        Id = id;
    }
}