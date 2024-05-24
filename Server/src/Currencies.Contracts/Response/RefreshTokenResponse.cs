using Currencies.Contracts.Helpers;

namespace Currencies.Contracts.Response;

public class RefreshTokenResponse
{
    public RefreshToken? RefreshToken { get; set; }
    public string? AccessToken { get; set; }
    public string? UserId { get; set; }
}