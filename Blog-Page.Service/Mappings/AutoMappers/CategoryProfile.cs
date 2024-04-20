using System;
using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.Category;
using Blog_Page.Domain.Entities;

namespace Blog_Page.Service.Mappings.AutoMappers
{
	public class CategoryProfile:Profile
	{
		public CategoryProfile()
		{
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
			CreateMap<CategoryListDto , UpdateCategoryDto>().ReverseMap();
        }
	}
}

