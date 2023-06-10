
using RealEstate.Application.Contracts.Persistence;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Properties.Queries.GetPropertyDetail;

namespace RealEstate.Application.UnitTests.Features.Properties.Queries;

public class GetPropertyDetailQueryHandlerTests
{
    private readonly IUserRepository _userRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IBookmarkRepository _bookmarkRepository;

    public GetPropertyDetailQueryHandlerTests()
    {
        _propertyRepository = MockPropertyRepository.GetPropertyRepository();
        _bookmarkRepository = MockBookmarkRepository.GetBookmarkRepository();
        _userRepository = MockUserRepository.GetUserRepository();
    }

    [Fact]
    public async Task GetPropertyDetailTest()
    {
        var handler = new GetPropertyDetailQueryHandler(_propertyRepository, _bookmarkRepository, _userRepository);
        var result = await handler.Handle(new GetPropertyDetailQuery()
        {
            EmailAddress = "john.doe@gmail.com",
            PropertyId = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f")
        },
            CancellationToken.None);
        Assert.NotNull(result);
        result.Name.ShouldBe("Jumeirah Metro City");
    }
}
