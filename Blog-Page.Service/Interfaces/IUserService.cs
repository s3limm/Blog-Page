using System;
using System.Linq.Expressions;
using Blog_Page.Domain.BlogPage.Dtos.User;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.User.Request;

namespace Blog_Page.Service.Interfaces
{
	public interface IUserService
	{
        Task<List<UserListDto>> GetListAsync();
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
        Task<UserListDto> FindAsync(int id);
        Task CreateAsync(CreateUserDto dto);
        Task UpdateAsync(UpdateUserDto dto);
        Task DeleteAsync(UserListDto dto);
        //Task<AppUser> CheckUserAsync(CheckUserDto dto);
    }
}

