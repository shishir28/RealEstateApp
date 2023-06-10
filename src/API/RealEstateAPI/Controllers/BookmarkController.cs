using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark;

namespace RealEstateAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookmarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookmarkController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost(Name = "CreateBookmark")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateBookmark([FromBody] CreateBookmarkCommand createBookmarkCommand)
    {
        var id = await _mediator.Send(createBookmarkCommand);
        return Ok(id);
    }
}
