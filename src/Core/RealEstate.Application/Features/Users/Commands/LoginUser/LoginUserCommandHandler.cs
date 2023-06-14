using MediatR;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // the whole implementation should use the Asp.Net Identity but lets keep it simple for now
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user != null)
            {
                if (user.Password == request.Password)
                    return user;
            }
            return null;
        }
    }
}
