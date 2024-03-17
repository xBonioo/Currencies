using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.Api.Controllers;

/// <summary>
/// For information on how to use the various controllers, go to:
/// 'https wiki-link'
/// </summary>
[Route("api/user-history")]
[ApiController]
public class UserExchangeHistoryController : Controller
{
    private readonly IMediator _mediator;

    public UserExchangeHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all available user exchange histories
    /// </summary>
    /// <response code="200">Returns all available user exchange histories.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public async Task<ActionResult<BaseResponse<PageResult<UserExchangeHistoryDto>>>> GetAllUserExchangeHistories()
    {
        var result = new PageResult<UserExchangeHistoryDto>(null, 1, 1, 1);
        if (result is null)
        {
            return NotFound(new BaseResponse<PageResult<UserExchangeHistoryDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user exchange histories"
            });
        }

        return Ok(new BaseResponse<PageResult<UserExchangeHistoryDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<UserExchangeHistoryDto>>> GetUserExchangeHistoryById(int id)
    {

        return Ok();
    }
}