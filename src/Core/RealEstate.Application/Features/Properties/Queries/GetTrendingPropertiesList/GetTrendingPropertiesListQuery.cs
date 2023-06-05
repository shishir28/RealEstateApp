using MediatR;
namespace RealEstate.Application.Features.Properties.Queries.GetTrendingPropertiesList
{
    public class GetTrendingPropertiesListQuery : IRequest<List<PropertyListVm>>
    {
    }
}
