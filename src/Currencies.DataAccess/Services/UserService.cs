using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Account;
using Currencies.Models;
using Microsoft.AspNetCore.Identity;
using Currencies.Contracts.ResponseModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Currencies.Contracts.ModelDtos.User;

namespace Currencies.DataAccess.Services;

public class UserService : IUserService
{
    private readonly TableContext _dbContext;

    public UserService(TableContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUserExchangeHistoryAsync(UserExchangeHistoryDto history)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserExchangeHistoryDto>> GetUserExchangeHistoryAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
