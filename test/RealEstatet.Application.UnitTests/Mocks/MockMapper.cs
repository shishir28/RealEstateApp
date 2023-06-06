
using AutoMapper;
using RealEstate.Application.Features.Profiles;
namespace RealEstate.Application.UnitTests.Mocks;

public class MockMapper
{
    public static IMapper CreateMapper()
    {
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        return mockMapper.CreateMapper();
    }
}
