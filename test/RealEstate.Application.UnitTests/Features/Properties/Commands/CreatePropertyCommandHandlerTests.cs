using RealEstate.Application.Contracts.Persistence;
using RealEstate.Application.Features.Properties.Commands.CreateProperty;
using RealEstate.Application.UnitTests.Mocks;
using Shouldly;

namespace RealEstatet.Application.UnitTests.Features.Properties.Commands
{
    public class CreatePropertyCommandHandlerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IPropertyRepository _propertyRepository;
        private ICategoryRepository _categoryRepository;
        public CreatePropertyCommandHandlerTests()
        {
            _categoryRepository = MockCategoryRepository.GetCategoryRepository();
            _propertyRepository = MockPropertyRepository.GetPropertyRepository();
            _userRepository = MockUserRepository.GetUserRepository();
        }

        [Fact]
        public async Task CreatePropertyTest()
        {
            var houseGuid = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b");
            var request = new CreatePropertyCommand
            {
                Name = "Sydney City",
                Detail = "A stunning property in offering",
                Address = "1000 West King, Ponds, NSW",
                ImageUrl = "imagep111.jpg",
                Price = 1000000,
                CategoryId = houseGuid
            };
            var handler = new CreatePropertyCommandHandler(_propertyRepository, _categoryRepository, _userRepository);
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<Guid>();
        }

    }
}
