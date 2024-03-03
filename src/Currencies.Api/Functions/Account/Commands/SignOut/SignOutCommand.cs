using MediatR;

namespace Currencies.Api.Functions.Account.Commands.SignOut;

public record SignOutCommand(string accessToken) : IRequest;