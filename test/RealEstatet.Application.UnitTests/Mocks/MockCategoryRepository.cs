using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Moq;

namespace RealEstate.Application.UnitTests.Mocks;

public class MockCategoryRepository
{
    public static ICategoryRepository GetCategoryRepository()
    {
        var houseGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b");
        var hotelGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c");
        var apartmentGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d");
        var penthouseGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e");

        var categories = new List<Category>
        {
            new Category { CategoryId = houseGuid, Name = "House" },
            new Category { CategoryId = hotelGuid, Name = "Hotel" },
            new Category { CategoryId = apartmentGuid, Name = "Apartment" },
            new Category { CategoryId = penthouseGuid, Name = "Penthouse" }
        };

        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(categories);
        // mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
        //     (Category category) =>
        //     {
        //         categories.Add(category);
        //         return category;
        //     });

        // mockCategoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(
        //     (Guid categoryId) =>
        //     {
        //         return categories.FirstOrDefault(x => x.CategoryId == categoryId);
        //     });

        return mockCategoryRepository.Object;

    }
}
