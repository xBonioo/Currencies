using Currencies.Contracts.Helpers;
using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.ModelDtos.Role;
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
[Route("api/role")]
[ApiController]
public class RoleController : Controller
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all available roles.
    /// </summary>
    /// <response code="200">Returns all available currencies.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    public async Task<ActionResult<BaseResponse<PageResult<RoleDto>>>> GetAllRoles()
    {
        var result = new PageResult<RoleDto>(null, 1, 1, 1);
        if (result is null)
        {
            return NotFound(new BaseResponse<PageResult<RoleDto>>
            {
                ResponseCode = StatusCodes.Status404NotFound,
                Message = $"There's no roles"
            });
        }

        return Ok(new BaseResponse<PageResult<RoleDto>>
        {
            ResponseCode = StatusCodes.Status200OK,
            Data = result
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<RoleDto>>> GetRoleById(int id)
    {

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<RoleDto>>> CreateCurrency([FromBody] CreateRoleDto dto)
    {

        return Ok();
    }

    [HttpGet("{id}/edit-form")]
    public async Task<ActionResult<BaseResponse<RoleEditForm>>> GetCurrencyEditForm(int id)
    {

        return Ok();
    }

    [HttpPost("{id}/edit")]
    public async Task<ActionResult<BaseResponse<RoleDto>>> UpdateCurrency(int id, [FromBody] UpdateRoleDto dto)
    {

        return NoContent();
    }

    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteCurrency(int id)
    {

        return NoContent();
    }
}