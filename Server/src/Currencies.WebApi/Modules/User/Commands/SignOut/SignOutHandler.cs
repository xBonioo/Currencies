using Currencies.Contracts.Interfaces;
using MediatR;

namespace Currencies.Api.Modules.User.Commands.SignOut;

public class SignOutHandler : IRequestHandler<SignOutCommand>
{
    private readonly IUserService _userService;

    public SignOutHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _userService.SignOutUserAsync(request.accessToken, cancellationToken);
    }
}