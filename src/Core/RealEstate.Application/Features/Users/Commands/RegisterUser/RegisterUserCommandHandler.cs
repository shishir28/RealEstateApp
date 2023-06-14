using FluentValidation.Results;
using MediatR;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Application.Exceptions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegisterUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if (await _userRepository.DoesUserNameExist(request.Email))
            {
                var validationErrors = new List<ValidationFailure> { new ()
                {
                    ErrorMessage = "User already exist"
                }};
                throw new ValidationException(new ValidationResult(validationErrors));
            }

            var toBeCreatedUser = new User
            {
                UserId = Guid.NewGuid(),
                Email = request.Email,
                Password = request.Password,
                Name = request.Name,
                Phone = request.Phone
            };
            var createdUser = await _userRepository.AddAsync(toBeCreatedUser);
            return createdUser.UserId;
        }
    }
}
