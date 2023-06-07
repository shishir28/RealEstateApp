using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Users.Command.RegisterUser;

namespace RealEstateAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) =>
        _mediator = mediator;

    [HttpPost(Name = "Register")]
    public async Task<ActionResult<Guid>> Register([FromBody] RegisterUserCommand registerUserCommand)
    {
        var id = await _mediator.Send(registerUserCommand);
        return Ok(id);
    }

}
