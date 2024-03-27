using System;
using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.Blog;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.Blog.Request;

namespace Blog_Page.Service.Mappings.AutoMappers
{
	public class BlogProfile:Profile
	{
		public BlogProfile()
		{
			CreateMap<Blog, BlogListDto>().ReverseMap();
			CreateMap<Blog, CreateBlogDto>().ReverseMap();
			CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<BlogListDto, UpdateBlogDto>().ReverseMap();
        }
	}
}

