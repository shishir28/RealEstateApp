namespace RealEstate.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; }
    }
}
