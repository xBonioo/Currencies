using MediatR;
using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.Response;

namespace Currencies.Api.Functions.User.Commands.SignIn;

public record SignInCommand(SignInDto dto) : IRequest<RefreshTokenResponse?>;