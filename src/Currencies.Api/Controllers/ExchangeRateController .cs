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

    [HttpGet]
    public async Task<ActionResult<BaseResponse<ExchangeRateDto>>> GetExchangeRate(int fromCurrencyId, int toCurrencyId)
    {

        return Ok();
    }

    [HttpPost("convert")]
    public async Task<ActionResult<BaseResponse<bool>>> Convert(int fromCurrencyId, int toCurrencyId, decimal amount)
    {

        return Ok();
    }

    [HttpPost("update")]
    public async Task<ActionResult<BaseResponse<bool>>> UpdateExchangeRates()
    {

        return NoContent();
    }
}