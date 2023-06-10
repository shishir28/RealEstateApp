using MediatR;
namespace RealEstate.Application.Features.Properties.Queries.GetPropertyDetail
{
    public class GetPropertyDetailQuery : IRequest<PropertyDetailVm>
    {
        public Guid PropertyId { get; set; }
    }
}
