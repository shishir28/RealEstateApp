using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Moq;

namespace RealEstate.Application.UnitTests.Mocks;

public class MockCategoryRepository
{
    public static ICategoryRepository GetCategoryRepository()
    {
        var houseGuid = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b");
        var hotelGuid = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c");
        var apartmentGuid = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d");
        var penthouseGuid = Guid.Parse("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e");

        var categories = new List<Category>
        {
            new Category { CategoryId = houseGuid, Name = "House" },
            new Category { CategoryId = hotelGuid, Name = "Hotel" },
            new Category { CategoryId = apartmentGuid, Name = "Apartment" },
            new Category { CategoryId = penthouseGuid, Name = "Penthouse" }
        };

        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(categories);
        mockCategoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
        .ReturnsAsync((Guid Id) =>
        {
            return categories.SingleOrDefault(x => x.CategoryId == Id);
        });
        return mockCategoryRepository.Object;
    }
}
