using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Properties.Queries;
using RealEstate.Application.Features.Properties.Queries.GetTrendingPropertiesList;
using RealEstate.Application.Features.Properties.Queries.GetPropertiesListByCategory;
using RealEstate.Application.Features.Properties.Queries.GetPropertiesListByAddress;
using RealEstate.Application.Features.Properties.Queries.GetPropertyDetail;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using RealEstate.Application.Features.Properties.Commands.CreateProperty;
using System.Net;

namespace RealEstateAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IMediator _mediator;

    public PropertyController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet("TrendingProperties", Name = "GetTrendingProperties")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<PropertyListVm>>> GetTrendingProperties()
    {
        try
        {
            var result = await _mediator.Send(new GetTrendingPropertiesListQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("PropertyList")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<PropertyListVm>>> GetProperties(Guid categoryId)
    {
        try
        {
            var result = await _mediator.Send(new GetPropertiesListByCategoryQuery() { CategoryId = categoryId });
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("SearchProperties", Name = "GetSearchProperties")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<PropertyListVm>>> GetSearchProperties(string address)
    {
        try
        {
            var result = await _mediator.Send(new GetPropertiesListByAddressQuery() { Address = address });
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("{propertyId}", Name = "GetPropertyDetail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PropertyDetailVm>> GetPropertyDetail(Guid propertyId)
    {
        try
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var dto = await _mediator.Send(new GetPropertyDetailQuery() { PropertyId = propertyId, EmailAddress = userEmail });
            return Ok(dto);
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPost(Name = "AddProperty")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> AddProperty(CreatePropertyCommand createPropertyCommand)
    {
        try
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            createPropertyCommand.EmailAddress = userEmail;
            var id = await _mediator.Send(createPropertyCommand);
            // 200 OK is not correct response type. it should be 201. Will come to it later
            return Ok(id);
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
