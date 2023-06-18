using MediatR;

namespace RealEstate.Application.Features.Properties.Commands.CreateProperty
{
    public class CreatePropertyCommand : IRequest<Guid>
    {
        public string? EmailAddress { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
