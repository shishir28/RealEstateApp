using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark;
using RealEstate.Application.Features.Bookmarks.Commands.DeleteBookmark;
using RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList;

namespace RealEstateAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookmarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookmarkController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet(Name = "GetBookmarks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBookmarks()
    {
        var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var bookmarks = await _mediator.Send(new GetBookmarksListQuery { EmailAddress = userEmail });
        return Ok(bookmarks);
    }

    [HttpPost(Name = "CreateBookmark")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateBookmark([FromBody] CreateBookmarkCommand createBookmarkCommand)
    {
        var id = await _mediator.Send(createBookmarkCommand);
        return Ok(id);
    }

    [HttpDelete("{bookmarkId}", Name = "DeleteBookmark")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBookmark(Guid bookmarkId)
    {
        var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        await _mediator.Send(new DeleteBookmarkCommand { BookmarkId = bookmarkId, EmailAddress = userEmail });
        return NoContent();
    }
}
