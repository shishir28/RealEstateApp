using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Categories.Queries.GetCategoriesList;
namespace RealEstateAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet(Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ResponseCache(Duration = 300)]
    public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
    {
        try
        {
            var categories = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(categories);
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
