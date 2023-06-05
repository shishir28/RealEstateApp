using AutoMapper;
using RealEstate.Application.Contracts.Persistence;
using MediatR;
using RealEstate.Application.Features.Properties.Queries.GetTrendingPropertiesList;
namespace RealEstate.Application.Features.Properties.Queries.GetTrendingPropertiesList;

public class GetTrendingPropertiesListQueryHandler : IRequestHandler<GetTrendingPropertiesListQuery, List<PropertyListVm>>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;
    public GetTrendingPropertiesListQueryHandler(IMapper mapper, IPropertyRepository propertyRepository)
    {
        _mapper = mapper;
        _propertyRepository = propertyRepository;
    }
    public async Task<List<PropertyListVm>> Handle(GetTrendingPropertiesListQuery request, CancellationToken cancellationToken)
    {
        var allTrendingProperties = (await _propertyRepository.GetTrendingProperties()).OrderBy(x => x.Name);
        return _mapper.Map<List<PropertyListVm>>(allTrendingProperties);
    }
}
