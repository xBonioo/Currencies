using MediatR;
using Currencies.Contracts.ModelDtos.Account;

namespace Currencies.Api.Functions.User.Commands.Register;

public class RegisterUserCommand : IRequest<UserDto>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}