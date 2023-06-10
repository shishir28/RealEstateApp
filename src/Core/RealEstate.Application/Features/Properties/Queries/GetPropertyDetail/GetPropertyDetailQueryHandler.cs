using AutoMapper;
using RealEstate.Application.Contracts.Persistence;
using MediatR;

namespace RealEstate.Application.Features.Properties.Queries.GetPropertyDetail;

public class GetPropertyDetailQueryHandler : IRequestHandler<GetPropertyDetailQuery, PropertyDetailVm>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;
    public GetPropertyDetailQueryHandler(IMapper mapper, IPropertyRepository propertyRepository)
    {
        _mapper = mapper;
        _propertyRepository = propertyRepository;
    }
    public async Task<PropertyDetailVm> Handle(GetPropertyDetailQuery request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepository.GetByIdAsync(request.PropertyId);
        var result = _mapper.Map<PropertyDetailVm>(property);
        return result;
    }
}
