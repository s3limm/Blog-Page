using AutoMapper;
using Blog_Page.Domain.Entities;
using Blog_Page.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Blog_Page.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryListModel, Category>().ReverseMap();
        }
    }
}
