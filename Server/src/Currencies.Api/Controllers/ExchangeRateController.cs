using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Api.Functions.Role.Commands.Create;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Api.Functions.Role.Queries.GetEditForm;
using Currencies.Api.Functions.ExchangeRate.Queries.GetEditForm;
using Currencies.Api.Functions.Role.Commands.Update;
using Currencies.Api.Functions.ExchangeRate.Commands.Update;
using Currencies.Api.Functions.Role.Commands.Delete;
using Currencies.Api.Functions.Role.Queries.GetAll;
using Currencies.Api.Functions.ExchangeRate.Queries.GetAll;
using Currencies.Api.Functions.Role.Queries.GetSingle;
using Currencies.Api.Functions.ExchangeRate.Queries.GetSingle;
using Currencies.Api.Functions.ExchangeRate.Commands.Create;
using Currencies.Api.Functions.ExchangeRate.Commands.Delete;

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

    [HttpPost]
    public async Task<ActionResult<BaseResponse<ExchangeRateDto>>> CreateExchangeRate([FromBody] BaseExchangeRateDto dto)
    {
        var result = await _mediator.Send(new CreateExchangeRateCommand(dto));
        if (result == null)
        {
            return BadRequest(new BaseResponse<ExchangeRateDto>
            {
                ResponseCode = StatusCodes.Status400BadRequest,
            });
        }

        return CreatedAtAction(nameof(CreateExchangeRate), new BaseResponse<ExchangeRateDto>
        {
            Message = "Role was created successfully",
            ResponseCode = StatusCodes.Status201Created,
            Data = result
        });
    }

    [HttpGet("{id}/edit-form")]
    public async Task<ActionResult<BaseResponse<ExchangeRateEditForm>>> GetExchangeRateEditForm(int id)
    {
        var result = await _mediator.Send(new GetExchangeRateEditFormQuery(id));
        if (result == null)
        {
            return NotFound(new BaseResponse<ExchangeRateEditForm>
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