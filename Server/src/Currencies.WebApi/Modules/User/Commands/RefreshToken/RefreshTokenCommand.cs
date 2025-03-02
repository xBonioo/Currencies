using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.User.Commands.RefreshToken;

public record RefreshTokenCommand(string refreshToken, string accessToken) : IRequest<RefreshTokenResponse?>;