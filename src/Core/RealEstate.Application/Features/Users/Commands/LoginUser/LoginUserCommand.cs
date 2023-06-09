﻿using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<ApplicationUser>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
