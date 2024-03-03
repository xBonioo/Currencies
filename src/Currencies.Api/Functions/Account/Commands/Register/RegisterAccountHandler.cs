using MediatR;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Account;

namespace Currencies.Api.Functions.Account.Commands.Register;

public class RegisterAccountHandler : IRequestHandler<RegisterAccountCommand, AccountDto>
{
    public IAccountService _accountService { get; set; }

    public RegisterAccountHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public Task<AccountDto> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        return _accountService.RegisterUserAsync(request.RegisterUserDto);
    }
}