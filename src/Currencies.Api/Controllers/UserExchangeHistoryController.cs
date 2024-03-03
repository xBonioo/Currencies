using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.Api.Controllers;

/// <summary>
/// For information on how to use the various controllers, go to:
/// 'https wiki-link'
/// </summary>
[Route("api/user-exchange-history")]
[ApiController]
public class UserExchangeHistoryController : Controller
{
    private readonly IMediator _mediator;

    public UserExchangeHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<PageResult<CurrencyDto>>>> GetAllUserExchangeHistory()
    {
        var result = new PageResult<CurrencyDto>(null, 1, 1, 1);
        if (result is null)
        {
            return NotFound(new BaseResponse<PageResult<CurrencyDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user history."
            });
        }

        return Ok(new BaseResponse<PageResult<CurrencyDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }
}