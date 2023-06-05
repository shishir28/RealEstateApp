using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Properties.Queries.GetTrendingPropertiesList;
namespace RealEstateAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IMediator _mediator;

    public PropertyController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet("TrendingProperties", Name = "GetTrendingProperties")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PropertyListVm>>> GetTrendingProperties()
    {
        var dtos = await _mediator.Send(new GetTrendingPropertiesListQuery());
        return Ok(dtos);
    }
}
