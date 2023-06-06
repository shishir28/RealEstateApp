
using RealEstate.Application.Contracts.Persistence;
using AutoMapper;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Categories.Queries.GetCategoriesList;

namespace RealEstate.Application.UnitTests.Features.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesListQueryHandlerTests()
    {
        _categoryRepository = MockCategoryRepository.GetCategoryRepository();
        _mapper = MockMapper.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCategoriesListQueryHandler(_mapper, _categoryRepository);
        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
        result.Count.ShouldBe(4);
    }
}
