using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Users.Commands.RegisterUser;
using RealEstate.Application.Features.Users.Commands.LoginUser;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace RealEstateAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _config;
    public UserController(IMediator mediator, IConfiguration config)
    {
        _mediator = mediator;
        _config = config;

    }


    [HttpPost(Name = "Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> Register([FromBody] RegisterUserCommand registerUserCommand)
    {
        var id = await _mediator.Send(registerUserCommand);
        return Ok(id);
    }

    [HttpPost("Login", Name = "Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Login([FromBody] LoginUserCommand loginUserCommand)
    {
        var user = await _mediator.Send(loginUserCommand);
        if (user == null)
        {
            return BadRequest("Invalid Credentials");
        }
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.Email , user.Email)
        };
        var token = new JwtSecurityToken(
               issuer: _config["JWT:Issuer"],
               audience: _config["JWT:Audience"],
               claims: claims,
               expires: DateTime.Now.AddDays(60),
               signingCredentials: credentials);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return new ObjectResult(new
        {
            access_token = jwt,
            token_type = "bearer",
            user_id = user.UserId,
            user_name = user.Name
        });
    }

}
/*
 "JWT": {
    "Key": "ZdYM000OLlMQG6VVVp1OH7Xarp7gHuw1qvUC5dcGt3SNM",
    "Issuer": "https://localhost:7022/",
    "Audience": "https://localhost:7022/"
  }
*/
