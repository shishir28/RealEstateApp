﻿using System.Net;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Bookmarks.Commands.CreateBookmark;
using RealEstate.Application.Features.Bookmarks.Commands.DeleteBookmark;
using RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList;

namespace RealEstateAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BookmarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookmarkController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet(Name = "GetBookmarks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBookmarks()
    {
        try
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var bookmarks = await _mediator.Send(new GetBookmarksListQuery { EmailAddress = userEmail });
            return Ok(bookmarks);
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPost(Name = "CreateBookmark")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateBookmarkCommandResponse>> CreateBookmark([FromBody] CreateBookmarkCommand createBookmarkCommand)
    {
        try
        {
            var response = await _mediator.Send(createBookmarkCommand);
            if (!response.Success)
                return new BadRequestResult();

            return Ok(response);

        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }

    }

    [HttpDelete("{bookmarkId}", Name = "DeleteBookmark")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBookmark(Guid bookmarkId)
    {
        try
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            await _mediator.Send(new DeleteBookmarkCommand { BookmarkId = bookmarkId, EmailAddress = userEmail });
            return NoContent();
        }
        catch (Exception ex)
        {
            // Handle the exception, log it, and return an appropriate error response
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
