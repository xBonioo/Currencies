using MediatR;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Api.Functions.User.Commands.RefreshToken;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse?>
{
    private readonly IUserService _userService;

    public RefreshTokenHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RefreshTokenResponse?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await _userService.RefreshTokenAsync(request.refreshToken, request.accessToken, cancellationToken);
    }
}