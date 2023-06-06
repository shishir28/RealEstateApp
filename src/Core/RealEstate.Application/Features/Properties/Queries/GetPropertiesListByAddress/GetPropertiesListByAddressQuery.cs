using MediatR;
namespace RealEstate.Application.Features.Properties.Queries.GetPropertiesListByAddress
{
    public class GetPropertiesListByAddressQuery : IRequest<List<PropertyListVm>>
    {
        public string Address { get; set; }
    }
}
