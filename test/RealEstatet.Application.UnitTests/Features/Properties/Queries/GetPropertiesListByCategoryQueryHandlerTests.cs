
using RealEstate.Application.Contracts.Persistence;
using AutoMapper;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Properties.Queries.GetPropertiesListByCategory;

namespace RealEstate.Application.UnitTests.Features.Properties.Queries;

public class GetPropertiesListByCategoryQueryHandlerTests
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly ICategoryRepository _categoryRepository;

    private readonly IMapper _mapper;

    public GetPropertiesListByCategoryQueryHandlerTests()
    {
        _categoryRepository = MockCategoryRepository.GetCategoryRepository();
        _propertyRepository = MockPropertyRepository.GetPropertyRepository();

        _mapper = MockMapper.CreateMapper();
    }

    [Fact]
    public async Task GetPropertiesByCategoryIdTest()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        var houseCategoryGuid = categories.SingleOrDefault(_ => _.Name == "House").CategoryId;

        var handler = new GetPropertiesListByCategoryQueryHandler(_mapper, _propertyRepository);
        var result = await handler.Handle(new GetPropertiesListByCategoryQuery() { CategoryId = houseCategoryGuid }, CancellationToken.None);
        result.Count.ShouldBe(3);
    }
}
