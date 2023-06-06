using AutoMapper;
using RealEstate.Application.Contracts.Persistence;
using MediatR;
using RealEstate.Application.Features.Properties.Queries.GetPropertiesListByAddress;
namespace RealEstate.Application.Features.Properties.Queries.GetPropertiesListByAddress;

public class GetPropertiesListByAddressQueryHandler : IRequestHandler<GetPropertiesListByAddressQuery, List<PropertyListVm>>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;
    public GetPropertiesListByAddressQueryHandler(IMapper mapper, IPropertyRepository propertyRepository)
    {
        _mapper = mapper;
        _propertyRepository = propertyRepository;
    }

    public async Task<List<PropertyListVm>> Handle(GetPropertiesListByAddressQuery request, CancellationToken cancellationToken)
    {
        var allProperties = (await _propertyRepository.GetPropertiesForAddress(request.Address)).OrderBy(x => x.Name);
        return _mapper.Map<List<PropertyListVm>>(allProperties);
    }
}
