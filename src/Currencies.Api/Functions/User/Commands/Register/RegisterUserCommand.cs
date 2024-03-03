using MediatR;
using Currencies.Contracts.ModelDtos.User;

namespace Currencies.Api.Functions.User.Commands.Register;

public class RegisterUserCommand : IRequest<UserDto>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}