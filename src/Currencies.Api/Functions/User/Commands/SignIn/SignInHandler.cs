using MediatR;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Api.Functions.User.Commands.SignIn;

public class SignInHandler : IRequestHandler<SignInCommand, RefreshTokenResponse?>
{
    private readonly IAccountService _accountService;

    public SignInHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<RefreshTokenResponse?> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.SignInUserAsync(request.dto);
    }
}