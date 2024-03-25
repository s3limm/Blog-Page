using System;
using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.User;
using Blog_Page.Domain.Entities;

namespace Blog_Page.Service.Mappings.AutoMapper
{
	public class UserProfile:Profile
	{
		public UserProfile()
		{
            CreateMap<AppUser, UserListDto>().ReverseMap();
            CreateMap<AppUser, CreateUserDto>().ReverseMap();
            CreateMap<AppUser, UpdateUserDto>().ReverseMap();
        }
	}
}

