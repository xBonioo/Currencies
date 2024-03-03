using MediatR;
using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Api.Functions.User.Commands.SignIn;

public record SignInCommand(SignInDto dto) : IRequest<RefreshTokenResponse?>;