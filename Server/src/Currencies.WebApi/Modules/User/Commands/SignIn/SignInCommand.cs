using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Modules.User.Commands.SignIn;

public record SignInCommand(SignInDto dto) : IRequest<RefreshTokenResponse?>;