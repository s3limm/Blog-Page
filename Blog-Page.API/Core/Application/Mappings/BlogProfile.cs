using AutoMapper;
using Blog_Page.API.Core.Application.Dtos;
using Blog_Page.API.Core.Domain;

namespace Blog_Page.API.Core.Application.Mappings
{
    public class BlogProfile:Profile
    {
        public BlogProfile() 
        {
            CreateMap<Blog, BlogListDto>().ReverseMap();
        }
    }
}
