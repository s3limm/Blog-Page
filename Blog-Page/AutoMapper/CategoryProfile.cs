using AutoMapper;
using Blog_Page.Dto;
using Blog_Page.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Blog_Page.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
