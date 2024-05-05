using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Currencies.Api.Functions.ExchangeRate.Queries.GetEditForm;
using Currencies.Api.Functions.ExchangeRate.Commands.Update;
using Currencies.Api.Functions.ExchangeRate.Queries.GetAll;
using Currencies.Api.Functions.ExchangeRate.Queries.GetSingle;
using Currencies.Api.Functions.ExchangeRate.Commands.Create;
using Currencies.Api.Functions.ExchangeRate.Commands.Delete;
using Microsoft.AspNetCore.Authorization;

namespace Currencies.Api.Controllers;

/// <summary>
/// For information on how to use the various controllers, go to:
/// 'https wiki-link'
/// </summary>
//[Authorize]
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
    public async Task<ActionResult<BaseResponse<PageResult<ExchangeRateDto>>>> GetAllExchangeRates([FromQuery] FilterExchangeRateDto filter)
    {
        var result = await _mediator.Send(new GetExchangeRatesListQuery(filter));
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

    /// <summary>
    /// Returns exchange rate by id.
    /// </summary>
    /// <response code="200">Searched exchange rate.</response>
    /// <response code="404">Exchange rate not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<ExchangeRateDto>>> GetExchangeRateById(int id)
    {
        var result = await _mediator.Send(new GetSingleExchangeRateQuery(id));
        if (result == null)
        {
            return NotFound(new BaseResponse<ExchangeRateDto>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no exchange rate"
            });
        }

        return Ok(new BaseResponse<ExchangeRateDto>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Retrieves exchange rates from the National Bank of Poland (NBP) API for specified currency and date.
    /// </summary>
    /// <param name="date">The date for which exchange rates are requested in the format YYYY-MM-DD. (Only working days)</param>
    /// <returns>Returns a list of currency exchange rates from the NBP API or an error message if something goes wrong.</returns>
    /// <response code="201">Returns the list of exchange rates for the requested currency and date.</response>
    /// <response code="400">Bad request - the input parameters are invalid (e.g., wrong date format or unsupported currency code).</response>
    /// <response code="404">Not found - no exchange rates found for the provided currency and date.</response>
    /// <response code="500">Internal server error - error during processing the request.</response>
    [HttpPost]
    public async Task<ActionResult<BaseResponse<List<ExchangeRateDto>>>> CreateExchangeRate([FromBody] DateTime date)
    {
        var result = await _mediator.Send(new CreateExchangeRateCommand(date));
        if (result == null)
        {
            return BadRequest(new BaseResponse<ExchangeRateDto>
            {
                ResponseCode = StatusCodes.Status400BadRequest,
            });
        }

        return CreatedAtAction(nameof(CreateExchangeRate), new BaseResponse<List<ExchangeRateDto>>
        {
            Message = "ExchangeRates were created successfully",
            ResponseCode = StatusCodes.Status201Created,
            Data = result
        });
    }

    /// <summary>
    /// Get edit form of exchange rate.
    /// </summary>
    /// <response code="200">Exchange rate edit form correctly response.</response>
    [HttpGet("{id}/edit-form")]
    public async Task<ActionResult<BaseResponse<ExchangeRateEditForm?>>> GetExchangeRateEditForm(int id)
    {
        var result = await _mediator.Send(new GetExchangeRateEditFormQuery(id));
        if (result == null)
        {
            return NotFound(new BaseResponse<ExchangeRateEditForm?>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no exchange rate with Id: {id}"
            });
        }

        return Ok(new BaseResponse<ExchangeRateEditForm>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Updates exchange rate - it's all properties.
    /// </summary>
    /// <response code="200">Exchange rate correctly updated.</response>
    /// <response code="400">Please insert correct JSON object with parameters.</response>
    /// <response code="404">Exchange rate not found.</response>
    [HttpPost("{id}/edit")]
    public async Task<ActionResult<BaseResponse<ExchangeRateDto>>> UpdateExchangeRate(int id, [FromBody] BaseExchangeRateDto dto)
    {
        var result = await _mediator.Send(new UpdateExchangeRateCommand(id, dto));
        if (result == null)
        {
            return NotFound(new BaseResponse<ExchangeRateDto>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no exchange rate with Id: {id}"
            });
        }

        return Ok(new BaseResponse<ExchangeRateDto>
        {
            Message = "Exchange rate was updated successfully",
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Deletes exchange rate. (Changes flag "IsActive" to false - Soft delete))
    /// </summary>
    /// <response code="200">Exchange rate correctly deleted.</response>
    /// <response code="404">Exchange rate not found.</response>
    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteExchangeRate(int id)
    {
        var result = await _mediator.Send(new DeleteExchangeRateCommand(id));
        if (!result)
        {
            return NotFound(new BaseResponse<bool>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no exchange rate with Id: {id}"
            });
        }

        return Ok(new BaseResponse<bool>
        {
            Message = "Exchange rate was deleted successfully",
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }
}