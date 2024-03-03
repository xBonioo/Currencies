using MediatR;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Api.Functions.Account.Commands.RefreshToken;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse?>
{
    private readonly IAccountService _accountService;

    public RefreshTokenHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<RefreshTokenResponse?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.RefreshTokenAsync(request.refreshToken, request.accessToken);
    }
}