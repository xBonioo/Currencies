using MediatR;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User;

namespace Currencies.Api.Functions.User.Commands.Register;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
{
    public IUserService _userService { get; set; }

    public RegisterUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return _userService.RegisterUserAsync(request.RegisterUserDto, cancellationToken);
    }
}