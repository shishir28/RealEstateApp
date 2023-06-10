using MediatR;
using RealEstate.Application.Contracts.Persistence;
using RealEstate.Application.Exceptions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Properties.Commands.CreateProperty
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPropertyRepository _propertyRepository;
        private ICategoryRepository _categoryRepository;
        public CreatePropertyCommandHandler(IPropertyRepository propertyRepository, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _propertyRepository = propertyRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.EmailAddress) ?? throw new NotFoundException(nameof(User), request.EmailAddress);
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new NotFoundException(nameof(Category), request.CategoryId);

            var result = await _propertyRepository.AddAsync(new Property
            {
                Name = request.Name,
                Detail = request.Detail,
                Address = request.Address,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
                IsTrending = false,
                UserId = user.UserId,
                CategoryId = request.CategoryId
            });
            return result.PropertyId;
        }
    }
}
