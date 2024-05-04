﻿using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Helpers;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Api.Functions.UserCurrencyAmount.Queries.GetSingle;
using Currencies.Api.Functions.UserCurrencyAmount.Queries.GetEditForm;
using Currencies.Api.Functions.UserCurrencyAmount.Commands.Create;
using Currencies.Api.Functions.Role.Commands.Update;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Api.Functions.Role.Commands.Delete;
using Currencies.Api.Functions.UserCurrencyAmount.Commands.Delete;
using Currencies.Api.Functions.Currency.Queries.GetAll;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Api.Functions.UserCurrencyAmount.Queries.GetAll;

namespace Currencies.Api.Controllers;

/// <summary>
/// For information on how to use the various controllers, go to:
/// 'https wiki-link'
/// </summary>
[Route("api/user-amount")]
[ApiController]
public class UserCurrencyAmountController : Controller
{
    private readonly IMediator _mediator;

    public UserCurrencyAmountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all available user currency amounts.
    /// </summary>
    /// <response code="200">Returns all available user currency amounts.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public async Task<ActionResult<BaseResponse<PageResult<UserCurrencyAmountDto>>>> GetAllUserCurrencyAmounts([FromQuery] FilterUserCurrencyAmountDto filter)
    {
        var result = await _mediator.Send(new GetUserCurrencyAmountsListQuery(filter));
        if (result == null)
        {
            return NotFound(new BaseResponse<PageResult<UserCurrencyAmountDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user currency amounts"
            });
        }

        return Ok(new BaseResponse<PageResult<UserCurrencyAmountDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Returns user currency amount by id.
    /// </summary>
    /// <response code="200">Searched user currency amount.</response>
    /// <response code="404">User currency amount not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> GetUserCurrencyAmountById(int id)
    {
        var result = await _mediator.Send(new GetSingleUserCurrencyAmountQuery(id));
        if (result == null)
        {
            return NotFound(new BaseResponse<UserCurrencyAmountDto>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user currency amount with Id: {id}"
            });
        }

        return Ok(new BaseResponse<UserCurrencyAmountDto>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Convert currency.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> ConvertUserCurrencyAmount([FromBody] ConvertUserCurrencyAmountDto dto)
    {

        return Ok();
    }

    /// <summary>
    /// Get create/edit form of user currency amount.
    /// </summary>
    /// <response code="200">User currency amount edit form correctly response.</response>
    [HttpGet("{id}/edit-form")]
    public async Task<ActionResult<BaseResponse<ExchangeRateEditForm>>> GetUserCurrencyAmountEditForm(int id)
    {
        var result = await _mediator.Send(new GetUserCurrencyAmountEditFormQuery(id));
        if (result == null)
        {
            return NotFound(new BaseResponse<UserCurrencyAmountEditForm>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user currency amount with Id: {id}"
            });
        }

        return Ok(new BaseResponse<UserCurrencyAmountEditForm>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Adds user currency amount.
    /// </summary>
    /// <response code="201">User currency amount correctly added.</response>
    /// <response code="400">Please insert correct JSON object with parameters.</response>
    [HttpPost("{id}/add")]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> AddUserCurrencyAmount(int id, [FromBody] BaseUserCurrencyAmountDto dto)
    {

        var result = await _mediator.Send(new CreateUserCurrencyAmountCommand(id, dto));
        if (result == null)
        {
            return BadRequest(new BaseResponse<UserCurrencyAmountDto>
            {
                ResponseCode = StatusCodes.Status400BadRequest,
            });
        }

        return CreatedAtAction(nameof(AddUserCurrencyAmount), new BaseResponse<UserCurrencyAmountDto>
        {
            Message = "User currency amount was created successfully",
            ResponseCode = StatusCodes.Status201Created,
            Data = result
        });
    }

    /// <summary>
    /// Updates user currency amount - it's all properties.
    /// </summary>
    /// <response code="200">User currency amount correctly updated.</response>
    /// <response code="400">Please insert correct JSON object with parameters.</response>
    /// <response code="404">User currency amount not found.</response>
    [HttpPost("{id}/edit")]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> UpdateUserCurrencyAmount(int id, [FromBody] BaseUserCurrencyAmountDto dto)
    {
        var result = await _mediator.Send(new UpdateUserCurrencyAmountCommand(id, dto));
        if (result == null)
        {
            return NotFound(new BaseResponse<UserCurrencyAmountDto>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user currency amount with Id: {id}"
            });
        }

        return Ok(new BaseResponse<UserCurrencyAmountDto>
        {
            Message = "User currency amount was updated successfully",
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    /// <summary>
    /// Deletes user currency amount. (Changes flag "IsActive" to false - Soft delete))
    /// </summary>
    /// <response code="200">User currency amount correctly deleted.</response>
    /// <response code="404">User currency amount not found.</response>
    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteUserCurrencyAmount(int id)
    {
        var result = await _mediator.Send(new DeleteUserCurrencyAmountCommand(id));
        if (!result)
        {
            return NotFound(new BaseResponse<bool>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no user currency amount with Id: {id}"
            });
        }

        return Ok(new BaseResponse<bool>
        {
            Message = "User currency amount was deleted successfully",
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }
}