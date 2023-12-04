using AutoMapper;
using Blog_Page.API.Core.Application.Dtos.User;
using Blog_Page.API.Core.Domain;

namespace Blog_Page.API.Core.Application.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserResponseDto>().ReverseMap();
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
        }
    }
}
