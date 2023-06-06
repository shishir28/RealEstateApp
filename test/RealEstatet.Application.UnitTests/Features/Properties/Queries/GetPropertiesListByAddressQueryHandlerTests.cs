
using RealEstate.Application.Contracts.Persistence;
using AutoMapper;
using Shouldly;
using RealEstate.Application.UnitTests.Mocks;
using RealEstate.Application.Features.Properties.Queries.GetPropertiesListByAddress;

namespace RealEstate.Application.UnitTests.Features.Properties.Queries;

public class GetPropertiesListByAddressQueryHandlerTests
{
    private readonly IPropertyRepository _propertyRepository;

    private readonly IMapper _mapper;

    public GetPropertiesListByAddressQueryHandlerTests()
    {
        _propertyRepository = MockPropertyRepository.GetPropertyRepository();
        _mapper = MockMapper.CreateMapper();
    }

    [Fact]
    public async Task GetPropertiesByAddressTest()
    {
        var handler = new GetPropertiesListByAddressQueryHandler(_mapper, _propertyRepository);
        var result = await handler.Handle(new GetPropertiesListByAddressQuery() { Address = "Dorrabay, Dubai Marina, Dubai" }, CancellationToken.None);
        result.Count.ShouldBe(4);
    }
}
