using AutoMapper;
using Blog_Page.Domain.Entities;
using Blog_Page.Models;

namespace Blog_Page.Mapper
{
    public class BlogProfile:Profile
    {
        public BlogProfile()
        {
               CreateMap<BlogListModel,Blog>().ReverseMap();
        }
    }
}
