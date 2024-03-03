using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Contracts.Interfaces;

public interface IUserService
{
    Task<UserDto> RegisterUserAsync(RegisterUserDto dto, CancellationToken cancellationToken);
    Task<RefreshTokenResponse?> SignInUserAsync(SignInDto signInDto, CancellationToken cancellationToken);
    Task SignOutUserAsync(string accessToken, CancellationToken cancellationToken);
    Task<RefreshTokenResponse?> RefreshTokenAsync(string refreshToken, string accessToken, CancellationToken cancellationToken);
    Task<IEnumerable<UserExchangeHistoryRowDto>> GetUserExchangeHistoryAsync(string userId, CancellationToken cancellationToken);
    Task AddUserExchangeHistoryAsync(UserExchangeHistoryRowDto history, CancellationToken cancellationToken);
}
