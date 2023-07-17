using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApplicationUser>
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        
        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<ApplicationUser> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // the whole implementation should use the Asp.Net Identity but lets keep it simple for now
            
           var user = await _userManager.FindByEmailAsync(request.Email);
            
            if (user != null)
            {
                var vailidated = await _userManager.CheckPasswordAsync(user, request.Password);
                if (vailidated)
                {
                   await _signInManager.SignInAsync(user, true); ;
                   return user;
                };
            }
            return null;
        }
    }
}
