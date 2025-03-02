using Currencies.Contracts.Interfaces;
using Currencies.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Currencies.Models.Entities;
using Currencies.Contracts.ModelDtos.User;
using Microsoft.EntityFrameworkCore;
using Currencies.Contracts.Response;
using Microsoft.Extensions.Logging;

namespace Currencies.DataAccess.Services;

public class UserService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    TableContext dbContext,
    ITokenService tokenService,
    ILogger<UserService> logger)
    : IUserService
{
    public async Task<UserDto> RegisterUserAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = registerUserDto.UserName,
            Email = registerUserDto.Email,
            EmailConfirmed = true,
            RoleId = 2,
            IsActive = true,
            Adres = registerUserDto.Adres,
            IdentityNumber = registerUserDto.IdentityNumber,
            IDNumber = registerUserDto.IDNumber,
            IDExpiryDate = registerUserDto.IDExpiryDate,
            IDIssueDate = registerUserDto.IDIssueDate
        };

        using (var transaction = dbContext.Database.BeginTransaction())
        {
            var result = await userManager.CreateAsync(user, registerUserDto.Password);

            if (!result.Succeeded)
            {
                if (result.Errors.Count() > 1)
                {
                    throw new AggregateException("Multiple errors occured while creating user.",
                        result.Errors.Select(x => new Exception(x.Description)).ToList());
                }
                throw new Exception("Error occured while creating user: " + result.Errors.First().Description);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync();

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                IsActive = user.IsActive
            };
        }
    }

    public async Task<RefreshTokenResponse?> RefreshTokenAsync(string refreshToken, string accessToken, CancellationToken cancellationToken)
    {
        var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
        var userRefreshTokenRecord = dbContext.UserTokens.FirstOrDefault(u => u.Value == refreshToken);

        if (userRefreshTokenRecord == null)
        {
            return null;
        }

        var user = dbContext.Users.FirstOrDefault(u => u.Id == userRefreshTokenRecord.UserId);
        if (user == null)
        {
            return null;
        }

        if (!userRefreshTokenRecord.IsActive)
        {
            return null;
        }

        var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
        var newRefreshToken = tokenService.GenerateRefreshToken();

        userRefreshTokenRecord.Value = newRefreshToken.Token;
        userRefreshTokenRecord.ValidUntil = newRefreshToken.ValidUntil;

        await dbContext.SaveChangesAsync(cancellationToken);

        var response = new RefreshTokenResponse
        {
            RefreshToken = newRefreshToken,
            AccessToken = newAccessToken
        };

        return response;
    }

    public async Task<RefreshTokenResponse?> SignInUserAsync(SignInDto signInDto, CancellationToken cancellationToken)
    {
        try
        {
            var user = await userManager.Users
                            .Include(u => u.Role)
                            .FirstOrDefaultAsync(u => u.UserName == signInDto.Username);

            if (user is null)
            {
                return null;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, signInDto.Password, false, false);

            if (!signInResult.Succeeded)
            {
                return null;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var accessToken = tokenService.GenerateAccessToken(claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();
            var userRefreshTokenRecord = dbContext.UserTokens.FirstOrDefault(u => u.UserId == user.Id);
            if (userRefreshTokenRecord is null)
            {
                dbContext.UserTokens.Add(new TokenUser
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
            await dbContext.SaveChangesAsync(cancellationToken);
            var response = new RefreshTokenResponse
            {
                RefreshToken = newRefreshToken,
                AccessToken = accessToken,
                UserId = user.Id
            };

            return response;
        }
        catch (Exception e)
        {
            logger.LogError($"{e.Message}");
        }

        return null;
    }

    public async Task<bool> SignOutUserAsync(string accessToken, CancellationToken cancellationToken)
    {
        await signInManager.SignOutAsync();

        var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);

        var userId = principal.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;

        var userRefreshTokenRecord = dbContext.UserTokens.Single(u => u.UserId == userId);

        userRefreshTokenRecord.Value = null;
        userRefreshTokenRecord.ValidUntil = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
