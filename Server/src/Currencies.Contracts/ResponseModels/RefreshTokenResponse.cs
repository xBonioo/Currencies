using Currencies.Contracts.Helpers;

namespace Currencies.Contracts.ResponseModels;

public class RefreshTokenResponse
{
    public RefreshToken? RefreshToken { get; set; }
    public string? AccessToken { get; set; }
}