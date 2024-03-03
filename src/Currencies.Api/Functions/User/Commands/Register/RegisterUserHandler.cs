using MediatR;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Account;

namespace Currencies.Api.Functions.User.Commands.Register;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
{
    public IAccountService _accountService { get; set; }

    public RegisterUserHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return _accountService.RegisterUserAsync(request.RegisterUserDto);
    }
}