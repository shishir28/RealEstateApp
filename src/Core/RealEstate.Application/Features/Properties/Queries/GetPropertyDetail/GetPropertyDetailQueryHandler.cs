using RealEstate.Application.Contracts.Persistence;
using MediatR;
using RealEstate.Application.Exceptions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Properties.Queries.GetPropertyDetail;

public class GetPropertyDetailQueryHandler : IRequestHandler<GetPropertyDetailQuery, PropertyDetailVm>
{
    private readonly IUserRepository _userRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IBookmarkRepository _bookmarkRepository;

    public GetPropertyDetailQueryHandler(IPropertyRepository propertyRepository, IBookmarkRepository bookmarkRepository, IUserRepository userRepository)
    {
        _propertyRepository = propertyRepository;
        _bookmarkRepository = bookmarkRepository;
        _userRepository = userRepository;
    }

    public async Task<PropertyDetailVm> Handle(GetPropertyDetailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.EmailAddress) ?? throw new NotFoundException(nameof(User), request.EmailAddress);
        var property = await _propertyRepository.GetByIdAsync(request.PropertyId) ?? throw new NotFoundException(nameof(Property), request.PropertyId);
        var bookmarks = await _bookmarkRepository.GetActiveBookmarksByUserIdAsync(user.UserId) ?? throw new NotFoundException(nameof(Bookmark), user.UserId);
        var response = new PropertyDetailVm
        {
            PropertyId = property.PropertyId,
            Name = property.Name,
            Detail = property.Detail,
            Address = property.Address,
            Price = property.Price,
            ImageUrl = property.ImageUrl,
            PhoneNumber = user.Phone,
            Bookmark = bookmarks.FirstOrDefault(x=>x.PropertyId == request.PropertyId)
        };

        return response;
    }
}
