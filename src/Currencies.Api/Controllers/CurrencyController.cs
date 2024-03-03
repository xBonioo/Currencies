using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.Api.Controllers;

/// <summary>
/// For information on how to use the various controllers, go to:
/// 'https wiki-link'
/// </summary>
[Authorize]
[Route("api/currency")]
[ApiController]
public class CurrencyController : Controller
{
    private readonly IMediator _mediator;

    public CurrencyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all available currencies.
    /// </summary>
    /// <response code="200">Returns all available currencies.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public async Task<ActionResult<BaseResponse<PageResult<CurrencyDto>>>> GetAllCurrencies()
    {
        var result = new PageResult<CurrencyDto>(null, 1, 1, 1);
        if (result is null)
        {
            return NotFound(new BaseResponse<PageResult<CurrencyDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no currencies"
            });
        }

        return Ok(new BaseResponse<PageResult<CurrencyDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<CurrencyDto>>> GetCurrencyById(int id)
    {

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<CurrencyDto>>> CreateCurrency([FromBody] CurrencyDto currencyDto)
    {

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<BaseResponse<bool>>> UpdateCurrency(int id, [FromBody] CurrencyDto currencyDto)
    {

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteCurrency(int id)
    {

        return NoContent();
    }
}