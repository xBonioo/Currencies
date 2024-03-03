using Currencies.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Currencies.Api.Controllers;

/// <summary>
/// Weather Forecast
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Returns WeatherForecast
    /// </summary>
    /// <response code="200"></response>
    [HttpGet]
    public async Task<ActionResult<BaseResponse<IEnumerable<WeatherForecast>>>> Get()
    {
        return Ok(new BaseResponse<IEnumerable<WeatherForecast>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
        .ToArray()
        });
    }
}