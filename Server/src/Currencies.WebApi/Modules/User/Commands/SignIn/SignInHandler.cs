using Currencies.Contracts.Interfaces;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.User.Commands.SignIn;

public class SignInHandler : IRequestHandler<SignInCommand, RefreshTokenResponse?>
{
    private readonly IUserService _userService;

    public SignInHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RefreshTokenResponse?> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return await _userService.SignInUserAsync(request.dto, cancellationToken);
    }
}