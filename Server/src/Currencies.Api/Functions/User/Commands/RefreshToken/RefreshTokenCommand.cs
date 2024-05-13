using MediatR;
using Currencies.Contracts.Response;

namespace Currencies.Api.Functions.User.Commands.RefreshToken;

public record RefreshTokenCommand(string refreshToken, string accessToken) : IRequest<RefreshTokenResponse?>;