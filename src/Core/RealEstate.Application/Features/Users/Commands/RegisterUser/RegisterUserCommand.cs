using MediatR;

namespace RealEstate.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }        
    }
}
