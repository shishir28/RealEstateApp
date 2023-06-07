using AutoMapper;
using RealEstate.Application.Contracts.Persistence;
using MediatR;
namespace RealEstate.Application.Features.Properties.Queries.GetPropertiesListByCategory;

public class GetPropertiesListByCategoryQueryHandler : IRequestHandler<GetPropertiesListByCategoryQuery, List<PropertyListVm>>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;
    public GetPropertiesListByCategoryQueryHandler(IMapper mapper, IPropertyRepository propertyRepository)
    {
        _mapper = mapper;
        _propertyRepository = propertyRepository;
    }

    public async Task<List<PropertyListVm>> Handle(GetPropertiesListByCategoryQuery request, CancellationToken cancellationToken)
    {
        var allProperties = (await _propertyRepository.GetPropertiesByCategoryId(request.CategoryId)).OrderBy(x => x.Name);
        return _mapper.Map<List<PropertyListVm>>(allProperties);
    }
}
