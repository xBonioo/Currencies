using Currencies.Api.Functions.UserExchangeHistory.Queries.GetAll;
using Currencies.Api.Functions.UserExchangeHistory.Queries.GetSingle;
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
    public async Task<ActionResult<BaseResponse<PageResult<UserExchangeHistoryDto>>>> GetAllUserExchangeHistories([FromQuery] FilterUserExchangeHistoryDto filter)
    {
        var result = await _mediator.Send(new GetUserExchangeHistoryListQuery(filter));
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

    /// <summary>
    /// Returns user exchange histories by id.
    /// </summary>
    /// <response code="200">Searched user exchange histories.</response>
    /// <response code="404">User exchange histories not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<UserExchangeHistoryDto>>> GetUserExchangeHistoryById(int id)
    {

        var result = await _mediator.Send(new GetSingleUserExchangeHistoryQuery(id));
        if (result == null)
        {
            return NotFound(new BaseResponse<UserExchangeHistoryDto>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user exchange histories with Id: {id}"
            });
        }

        return Ok(new BaseResponse<UserExchangeHistoryDto>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }
}