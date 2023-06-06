using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Properties.Queries;
using RealEstate.Application.Features.Properties.Queries.GetTrendingPropertiesList;
using RealEstate.Application.Features.Properties.Queries.GetPropertiesListByCategory;
using RealEstate.Application.Features.Properties.Queries.GetPropertiesListByAddress;

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

    [HttpGet("PropertyList")]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PropertyListVm>>> GetProperties(Guid categoryId)
    {
        var dtos = await _mediator.Send(new GetPropertiesListByCategoryQuery() { CategoryId = categoryId });
        return Ok(dtos);
    }

    [HttpGet("SearchProperties")]
    // [Authorize]
    public async Task<ActionResult<List<PropertyListVm>>> GetSearchProperties(string address)
    {
        var dtos = await _mediator.Send(new GetPropertiesListByAddressQuery() { Address = address });
        return Ok(dtos);
    }
}
