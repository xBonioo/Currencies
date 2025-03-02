using Currencies.Contracts.ModelDtos.User;
using MediatR;

namespace Currencies.Api.Modules.User.Commands.Register;

public class RegisterUserCommand : IRequest<UserDto>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}