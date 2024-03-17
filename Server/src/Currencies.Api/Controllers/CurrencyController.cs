using Currencies.Api.Functions.Currency.Commands.Create;
using Currencies.Api.Functions.Currency.Commands.Delete;
using Currencies.Api.Functions.Currency.Commands.Update;
using Currencies.Api.Functions.Currency.Queries.GetAll;
using Currencies.Api.Functions.Currency.Queries.GetSingle;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.Helpers.Forms;
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
//[Authorize]
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
    public async Task<ActionResult<BaseResponse<PageResult<CurrencyDto>>>> GetAllCurrencies([FromQuery] FilterCurrencyDto filter)
    {
        var result = await _mediator.Send(new GetCurrenciesListQuery(filter));
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

    /// <summary>
    /// Returns currency by id.
    /// </summary>
    /// <response code="200">Searched currency.</response>
    /// <response code="404">Currency not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<CurrencyDto>>> GetCurrencyById(int id)
    {
        var result = await _mediator.Send(new GetSingleCurrencyQuery(id));
        if (result is null)
        {
            return NotFound(new BaseResponse<CurrencyDto>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no currency with Id: {id}"
            });
        }

        return Ok(new BaseResponse<CurrencyDto>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Creates Currency.
    /// </summary>
    /// <response code="201">Currency correctly created.</response>
    /// <response code="400">Please insert correct JSON object with parameters.</response>
    [HttpPost]
    public async Task<ActionResult<BaseResponse<CurrencyDto>>> CreateCurrency([FromBody] CreateCurrencyCommand command)
    {
        var result = await _mediator.Send(command);
        if (result is null)
        {
            return BadRequest(new BaseResponse<CurrencyDto>
            {
                ResponseCode = StatusCodes.Status400BadRequest,
            });
        }

        return CreatedAtAction(nameof(CreateCurrency), new BaseResponse<CurrencyDto>
        {
            Message = "Currency was created successfully",
            ResponseCode = StatusCodes.Status201Created,
            Data = result
        });
    }

    [HttpGet("{id}/edit-form")]
    public async Task<ActionResult<BaseResponse<CurrencyEditForm>>> GetCurrencyEditForm(int id)
    {

        return Ok();
    }

    /// <summary>
    /// Updates currency - it's all properties.
    /// </summary>
    /// <response code="200">Currency correctly updated.</response>
    /// <response code="400">Please insert correct JSON object with parameters.</response>
    /// <response code="404">Currency not found.</response>
    [HttpPost("{id}/edit")]
    public async Task<ActionResult<BaseResponse<CurrencyDto>>> UpdateCurrency(int id, [FromBody] BaseCurrencyDto dto)
    {
        var result = await _mediator.Send(new UpdateCurrencyCommand(id, dto));
        if (result != null)
        {
            return NotFound(new BaseResponse<bool>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no currency with Id: {id}"
            });
        }

        return Ok(new BaseResponse<CurrencyDto>
        {
            Message = "Currency was updated successfully",
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Deletes currency. (Changes flag "IsActive" to false - Soft delete))
    /// </summary>
    /// <response code="200">Currency correctly deleted.</response>
    /// <response code="404">Currency not found.</response>
    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteCurrency(int id)
    {
        var result = await _mediator.Send(new DeleteCurrencyCommand(id));
        if (!result)
        {
            return NotFound(new BaseResponse<bool>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no currency with Id: {id}"
            });
        }

        return Ok(new BaseResponse<bool>
        {
            Message = "Currency was deleted successfully",
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }
}