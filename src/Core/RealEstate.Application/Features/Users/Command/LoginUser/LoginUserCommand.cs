﻿using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Users.Command.LoginUser
{
    public class LoginUserCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}