using MediatR;
namespace RealEstate.Application.Features.Properties.Queries.GetPropertiesListByCategory
{
    public class GetPropertiesListByCategoryQuery : IRequest<List<PropertyListVm>>
    {
        public Guid CategoryId { get; set; }
    }
}
