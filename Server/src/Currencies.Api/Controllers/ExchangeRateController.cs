using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.Api.Controllers;

/// <summary>
/// For information on how to use the various controllers, go to:
/// 'https wiki-link'
/// </summary>
[Route("api/exchange")]
[ApiController]
public class ExchangeRateController : Controller
{
    private readonly IMediator _mediator;

    public ExchangeRateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all available exchange rates.
    /// </summary>
    /// <response code="200">Returns all available exchange rates.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public async Task<ActionResult<BaseResponse<PageResult<ExchangeRateDto>>>> GetAllExchangeRates()
    {
        var result = new PageResult<ExchangeRateDto>(null, 1, 1, 1);
        if (result is null)
        {
            return NotFound(new BaseResponse<PageResult<ExchangeRateDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no currencies"
            });
        }

        return Ok(new BaseResponse<PageResult<ExchangeRateDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<ExchangeRateDto>>> GetExchangeRateById(int id)
    {

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<ExchangeRateDto>>> CreateExchangeRate([FromBody] BaseExchangeRateDto dto)
    {

        return Ok();
    }

    [HttpGet("{id}/edit-form")]
    public async Task<ActionResult<BaseResponse<ExchangeRateEditForm>>> GetExchangeRateEditForm(int id)
    {

        return Ok();
    }

    [HttpPost("{id}/edit")]
    public async Task<ActionResult<BaseResponse<ExchangeRateDto>>> UpdateExchangeRate(int id, [FromBody] BaseExchangeRateDto dto)
    {

        return NoContent();
    }

    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteExchangeRate(int id)
    {

        return NoContent();
    }
}