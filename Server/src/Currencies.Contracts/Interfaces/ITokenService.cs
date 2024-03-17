using Currencies.Contracts.Helpers;
using System.Security.Claims;

namespace Currencies.Contracts.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    RefreshToken GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
}
