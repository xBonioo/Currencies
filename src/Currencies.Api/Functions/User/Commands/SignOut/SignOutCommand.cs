using MediatR;

namespace Currencies.Api.Functions.User.Commands.SignOut;

public record SignOutCommand(string accessToken) : IRequest;