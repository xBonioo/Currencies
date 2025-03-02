using MediatR;

namespace Currencies.Api.Modules.User.Commands.SignOut;

public record SignOutCommand(string accessToken) : IRequest;