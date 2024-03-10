using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Contracts.Interfaces;

public interface IUserService
{
    Task<UserDto> RegisterUserAsync(RegisterUserDto dto, CancellationToken cancellationToken);
    Task<RefreshTokenResponse?> SignInUserAsync(SignInDto signInDto, CancellationToken cancellationToken);
    Task<bool> SignOutUserAsync(string accessToken, CancellationToken cancellationToken);
    Task<RefreshTokenResponse?> RefreshTokenAsync(string refreshToken, string accessToken, CancellationToken cancellationToken);
}
