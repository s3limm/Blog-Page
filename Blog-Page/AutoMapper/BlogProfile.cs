using AutoMapper;
using Blog_Page.Dto;
using Blog_Page.Models;

namespace Blog_Page.AutoMapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>();
        }
    }
}
