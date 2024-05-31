using Currencies.Contracts.Interfaces;
using Currencies.DataAccess.Services;
using Currencies.Models;
using Xunit;
using AutoMapper;
using Currencies.DataAccess.Mappings;
using Currencies.Contracts.Response;
using Currencies.Contracts.ModelDtos;
using Currencies.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Currencies.Api.Functions.UserExchangeHistory.Queries.GetAll;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Api.Functions.UserExchangeHistory.Queries.GetSingle;
using Currencies.Contracts.ModelDtos.User;
using Currencies.Api.Functions.User.Commands.Register;

namespace Currencies.Tests;

public class UserControllerTests : IClassFixture<BaseTestFixture>
{
    private readonly TableContext _dbContext;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IUserExchangeHistoryService _userExchangeHistoryService;

    public UserControllerTests(BaseTestFixture fixture)
    {
        _dbContext = fixture._dbContext;
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfile());
        });
        _mapper = mappingConfig.CreateMapper();
        _userService = new UserService(_userManager, _signInManager, _dbContext, _tokenService);
        _userExchangeHistoryService = new UserExchangeHistoryService(_dbContext, _mapper);
    }

    [Fact]
    public async Task GetAllUserExchangeHistories_ReturnPageResult()
    {
        // arrange
        FilterUserExchangeHistoryDto filter = new()
        {
            PageNumber = 1,
            PageSize = 10
        };

        GetUserExchangeHistoryListQuery query = new(filter);
        GetUserExchangeHistoryListQueryHandler handler = new(_userExchangeHistoryService);

        // act
        var result = await handler.Handle(query, new CancellationToken());

        // assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<PageResult<UserExchangeHistoryDto>>(result);
    }

    [Fact]
    public async Task GetById_UserExchangeHistory_ReturnUserExchangeHistory()
    {
        // arrange
        var id = 1;

        GetSingleUserExchangeHistoryQuery query = new(id);
        GetSingleUserExchangeHistoryQueryHandler handler = new(_userExchangeHistoryService, _mapper);

        // act
        var result = await handler.Handle(query, new CancellationToken());

        // assert
        Assert.NotNull(result);
        Assert.Equal(id, result!.Id);
    }

}
