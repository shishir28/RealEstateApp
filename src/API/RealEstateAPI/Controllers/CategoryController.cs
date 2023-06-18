using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Categories.Queries.GetCategoriesList;
namespace RealEstateAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator) =>
        _mediator = mediator;

    [Authorize]
    [HttpGet(Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ResponseCache(Duration = 300)]
    public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
    {
        var categories = await _mediator.Send(new GetCategoriesListQuery());
        return Ok(categories);
    }
}
