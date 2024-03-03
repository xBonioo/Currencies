using MediatR;
using Currencies.Contracts.Interfaces;

namespace Currencies.Api.Functions.User.Commands.SignOut;

public class SignOutHandler : IRequestHandler<SignOutCommand>
{
    private readonly IAccountService _accountService;

    public SignOutHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _accountService.SignOutUserAsync(request.accessToken);
    }
}