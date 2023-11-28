using AutoMapper;
using Blog_Page.API.Core.Application.Dtos;
using Blog_Page.API.Core.Domain;

namespace Blog_Page.API.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryListDto, Category>().ReverseMap();
        }
    }
}
