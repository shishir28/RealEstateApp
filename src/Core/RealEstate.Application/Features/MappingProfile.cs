using AutoMapper;
using RealEstate.Application.Features.Bookmarks.Queries.GetBookmarksList;
using RealEstate.Application.Features.Categories.Queries.GetCategoriesList;
using RealEstate.Application.Features.Properties.Queries;

namespace RealEstate.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Category, CategoryListVm>().ReverseMap();
            CreateMap<Domain.Entities.Bookmark, BookmarkListVm>().ReverseMap();
            CreateMap<Domain.Entities.Property, PropertyListVm>().ReverseMap();
        }
    }
}
