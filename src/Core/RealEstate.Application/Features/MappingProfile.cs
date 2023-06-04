using AutoMapper;
using RealEstate.Application.Features.Categories.Queries.GetCategoriesList;
namespace RealEstate.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Category, CategoryListVm>().ReverseMap();
        }
    }

}
