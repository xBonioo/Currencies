using Currencies.Api.Functions.User.Commands.Register;
using Currencies.Api.Functions.User.Commands.RefreshToken;
using Currencies.Api.Functions.User.Commands.SignIn;
using Currencies.Api.Functions.User.Commands.SignOut;
using Currencies.Contracts.ResponseModels;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;

namespace Currencies.Api.Controllers;

/// <summary>
/// For information on how to use the various controllers, go to:
/// 'https wiki-link'
/// </summary>
[Authorize]
[Route("api/user")]
[ApiController]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Register new User and send confirmation email to User's email.
    /// </summary>
    /// <param name="registerUser">JSON object with properties defining a user to create</param>
    /// <response code="201">User was created successfully and confirmation email was sent.</response>
    /// <response code="401">Something wrong with given tokens propably</response>
    /// <response code="500">Confirmation link could not be created.</response>
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<BaseResponse<PageResult<UserDto>>>> RegisterUserAsync([FromBody] RegisterUserDto registerUser)
    {
        var result = await _mediator
            .Send(new RegisterUserCommand
            {
                RegisterUserDto = registerUser
            });

        return CreatedAtAction(nameof(RegisterUserAsync), new BaseResponse<UserDto>
        {
            ResponseCode = StatusCodes.Status201Created,
            Data = result,
            Message = "User was created successfully and confirmation email was sent."
        });
    }

    /// <summary>
    /// Action to sign in a user by username and password
    /// </summary>
    /// <param name="dto">JSON object with username, password and confirmed password</param>
    /// <response code="200">Successfully signed in</response>
    /// <response code="400">Username or password is not valid</response>
    /// <response code="401">Something wrong with given tokens propably</response>
    /// <response code="500">Internal server error</response>
    [AllowAnonymous]
    [HttpPost("signin")]
    public async Task<ActionResult<BaseResponse<RefreshTokenResponse>>> SignInUserAsync([FromBody] SignInDto dto)
    {
        var response = await _mediator.Send(new SignInCommand(dto));

        if (response is null)
        {
            return BadRequest(new BaseResponse<object>
            {
                ResponseCode = StatusCodes.Status400BadRequest,
                Data = null,
                Message = "Username or password is not valid"
            });
        }

        return Ok(new BaseResponse<RefreshTokenResponse>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = response,
            Message = "You have been signed in successfully"
        });
    }

    /// <summary>
    /// Action to sign out the user. The user's refresh token is beeing deleted from database.
    /// </summary>
    /// <response code="200">Successfully signed out</response>
    /// <response code="401">Something wrong with given tokens propably</response>
    /// <response code="500">Internal server error</response>
    [HttpPost("signout")]
    public async Task<ActionResult<BaseResponse<bool>>> SignOutUserAsync()
    {
        HttpContext.Request.Headers.TryGetValue("Authorization", out var accessToken);
        await _mediator.Send(new SignOutCommand(accessToken.ToString().Split(' ').Last()));

        return Ok(new BaseResponse<bool>
        {
            ResponseCode = StatusCodes.Status200OK,
            Message = "You have been signed out successfully"
        });
    }

    /// <summary>
    /// Generates a new acccess token (JWT). It is necessary to give an old access token in header 
    /// (the same way as when authorizing to protected resorces)
    /// and active refresh token in body
    /// </summary>
    /// <param name="refreshToken">A refresh token given afler signing in (and refreshing access token)</param>
    /// <response code="200">New access token and refresh token</response>
    /// <response code="401">Something wrong with given tokens propably</response>
    /// <response code="500">Internal server error</response>
    [HttpPost("refreshtoken")]
    public async Task<ActionResult<BaseResponse<RefreshTokenResponse>>> RefreshTokenAsync([FromBody] RefreshTokenDto refreshToken)
    {
        var isAccessTokenGiven = HttpContext.Request.Headers.TryGetValue("Authorization", out var accessToken);
        
        if (!isAccessTokenGiven)
        {
            return Unauthorized(new BaseResponse<object>
            {
                ResponseCode = StatusCodes.Status401Unauthorized,
                Data = null,
                Message = "Failed to generate new token"
            });
        }

        var response = await _mediator.Send(new RefreshTokenCommand(refreshToken.RefreshToken, 
                                                                    accessToken.ToString().Split(' ')[1]));

        if (response is null)
        {
            return Unauthorized(new BaseResponse<object>
            {
                ResponseCode = StatusCodes.Status401Unauthorized,
                Data = null,
                Message = "Failed to generate new token"
            });

        }

        return Ok(new BaseResponse<RefreshTokenResponse>
        {
            ResponseCode = StatusCodes.Status401Unauthorized,
            Data = response,
            Message = "Here is your new access token and refresh token"
        });
    }

    /// <summary>
    /// Retrieves the user's exchange history.
    /// </summary>
    /// <response code="200">Returns the user's exchange history.</response>
    /// <response code="401">Unauthorized. The access token is invalid or expired.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet("get-history")]
    public async Task<ActionResult<BaseResponse<PageResult<UserExchangeHistoryDto>>>> GetAllUserExchangeHistory()
    {
        var result = new PageResult<UserExchangeHistoryDto>(null, 1, 1, 1);
        if (result is null)
        {
            return NotFound(new BaseResponse<PageResult<UserDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user history."
            });
        }

        return Ok(new BaseResponse<PageResult<UserExchangeHistoryDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    [HttpGet("get-history/{id}")]
    public async Task<ActionResult<BaseResponse<UserExchangeHistoryDto>>> GetUserExchangeHistoryById(int id)
    {

        return Ok();
    }
}