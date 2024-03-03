using Currencies.Contracts.ModelDtos.Account;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Contracts.Interfaces;

public interface IAccountService
{
    Task<UserDto> RegisterUserAsync(RegisterUserDto dto);
    Task<RefreshTokenResponse?> SignInUserAsync(SignInDto signInDto);
    Task SignOutUserAsync(string accessToken);
    Task<RefreshTokenResponse?> RefreshTokenAsync(string refreshToken, string accessToken);
}
