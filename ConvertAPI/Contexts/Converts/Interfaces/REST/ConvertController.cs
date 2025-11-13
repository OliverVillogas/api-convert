using System.Net.Mime;
using ConvertAPI.Contexts.Converts.Domain.Services;
using ConvertAPI.Contexts.Converts.Interfaces.REST.Resources;
using ConvertAPI.Contexts.Converts.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ConvertAPI.Contexts.Converts.Interfaces.REST;

/// <summary>
///     REST API for Kilograms to Pounds conversion
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ConvertController(
    IConvertCommandService commandService,
    IConvertQueryService queryService) : ControllerBase
{
    /// <summary>
    ///     Converts kilograms to pounds
    /// </summary>
    /// <remarks>
    ///     Example:
    ///     POST /convert
    ///     { "kilograms": 10 }
    ///     Response:
    ///     { "kilograms": 10, "pounds": 22.0462 }
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(ConvertResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Convert([FromBody] CreateConvertResource? resource)
    {
        if (resource == null)
            return BadRequest(new { message = "Request body is required." });
        var command = ConvertResourceAssembler.ToCommandFromResource(resource);
        var convert = await commandService.Handle(command);
        var response = ConvertResourceAssembler.ToResourceFromEntity(convert);

        return Ok(response);
    }
}