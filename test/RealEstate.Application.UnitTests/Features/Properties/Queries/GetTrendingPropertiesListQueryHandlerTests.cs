
using RealEstate.Application.Contracts.Persistence;
using AutoMapper;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Properties.Queries.GetTrendingPropertiesList;

namespace RealEstate.Application.UnitTests.Features.Properties.Queries;

public class GetTrendingPropertiesListQueryHandlerTests
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;

    public GetTrendingPropertiesListQueryHandlerTests()
    {
        _propertyRepository = MockPropertyRepository.GetPropertyRepository();
        _mapper = MockMapper.CreateMapper();
    }

    [Fact]
    public async Task GetTrendingPropertiesListTest()
    {
        var handler = new GetTrendingPropertiesListQueryHandler(_mapper, _propertyRepository);
        var result = await handler.Handle(new GetTrendingPropertiesListQuery(), CancellationToken.None);
        result.Count.ShouldBe(12);
    }
}
