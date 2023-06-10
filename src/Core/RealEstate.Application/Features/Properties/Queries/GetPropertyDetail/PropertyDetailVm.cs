namespace RealEstate.Application.Features.Properties.Queries.GetPropertyDetail
{
    public class PropertyDetailVm
    {
        public Guid PropertyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool IsTrending { get; set; }
    }
}
