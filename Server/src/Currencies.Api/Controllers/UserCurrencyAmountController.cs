using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Helpers;
using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;

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
    public async Task<ActionResult<BaseResponse<PageResult<UserCurrencyAmountDto>>>> GetAllUserCurrencyAmounts()
    {
        var result = new PageResult<UserCurrencyAmountDto>(null, 1, 1, 1);
        if (result is null)
        {
            return NotFound(new BaseResponse<PageResult<UserCurrencyAmountDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no currencies"
            });
        }

        return Ok(new BaseResponse<PageResult<UserCurrencyAmountDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> GetUserCurrencyAmountById(int id)
    {

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> ConvertUserCurrencyAmount([FromBody] ConvertUserCurrencyAmountDto dto)
    {

        return Ok();
    }

    [HttpGet("{id}/edit-form")]
    public async Task<ActionResult<BaseResponse<ExchangeRateEditForm>>> GetUserCurrencyAmountEditForm(int id)
    {

        return Ok();
    }

    [HttpPost("{id}/add")]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> AddUserCurrencyAmount(int id, [FromBody] BaseUserCurrencyAmountDto dto)
    {

        return NoContent();
    }

    [HttpPost("{id}/edit")]
    public async Task<ActionResult<BaseResponse<UserCurrencyAmountDto>>> UpdateUserCurrencyAmount(int id, [FromBody] BaseUserCurrencyAmountDto dto)
    {

        return NoContent();
    }

    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteCurrency(int id)
    {

        return NoContent();
    }
}