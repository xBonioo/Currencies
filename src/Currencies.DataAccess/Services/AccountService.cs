using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Account;
using Currencies.Models;
using Microsoft.AspNetCore.Identity;
using Currencies.Contracts.ResponseModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Currencies.DataAccess.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly TableContext _dbContext;
    private readonly ITokenService _tokenService;

    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        TableContext dbContext, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _dbContext = dbContext;
        _tokenService = tokenService;
    }

    public async Task<AccountDto> RegisterUserAsync(RegisterUserDto registerUserDto)
    {
        var user = new ApplicationUser
        {
            UserName = registerUserDto.UserName,
            Email = registerUserDto.Email,
        };

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if (!result.Succeeded)
            {
                if (result.Errors.Count() > 1)
                {
                    throw new AggregateException("Multiple errors occured while creating user.",
                        result.Errors.Select(x => new Exception(x.Description)).ToList());
                }
                throw new Exception("Error occured while creating user: " + result.Errors.First().Description);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await transaction.CommitAsync();

            return new AccountDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };
        }
    }

    public async Task<RefreshTokenResponse?> RefreshTokenAsync(string refreshToken, string accessToken)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
        var userRefreshTokenRecord = _dbContext.UserTokens.FirstOrDefault(u => u.Value == refreshToken);

        if (userRefreshTokenRecord == null)
        {
            return null;
        }

        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userRefreshTokenRecord.UserId);
        if (user == null)
        {
            return null;
        }

        if (!userRefreshTokenRecord.IsActive)
        {
            return null;
        }

        var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        userRefreshTokenRecord.Value = newRefreshToken.Token;
        userRefreshTokenRecord.ValidUntil = newRefreshToken.ValidUntil;

        await _dbContext.SaveChangesAsync();

        var response = new RefreshTokenResponse
        {
            RefreshToken = newRefreshToken,
            AccessToken = newAccessToken
        };

        return response;
    }

    public async Task<RefreshTokenResponse?> SignInUserAsync(SignInDto signInDto)
    {
        var user = await _userManager.FindByNameAsync(signInDto.Username);

        if (user is null)
        {
            return null;
        }

        var signInResult = await _signInManager.PasswordSignInAsync(user, signInDto.Password, false, false);

        if (!signInResult.Succeeded)
        {
            return null;
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var accessToken = _tokenService.GenerateAccessToken(claims);
        var newRefreshToken = _tokenService.GenerateRefreshToken();
        var userRefreshTokenRecord = _dbContext.UserTokens.FirstOrDefault(u => u.UserId == user.Id);
        if (userRefreshTokenRecord is null)
        {
            _dbContext.UserTokens.Add(new TokenUser
            {
                UserId = user.Id,
                LoginProvider = "Own",
                Name = "RefreshToken",
                Value = newRefreshToken.Token,
                ValidUntil = newRefreshToken.ValidUntil,
            });
        }
        else
        {
            userRefreshTokenRecord.Value = newRefreshToken.Token;
            userRefreshTokenRecord.ValidUntil = newRefreshToken.ValidUntil;
        }
        await _dbContext.SaveChangesAsync();
        var response = new RefreshTokenResponse
        {
            RefreshToken = newRefreshToken,
            AccessToken = accessToken
        };

        return response;
    }

    public async Task SignOutUserAsync(string accessToken)
    {
        await _signInManager.SignOutAsync();

        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

        var userId = principal.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;

        var userRefreshTokenRecord = _dbContext.UserTokens.Single(u => u.UserId == userId);

        userRefreshTokenRecord.Value = null;
        userRefreshTokenRecord.ValidUntil = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
    }
}
