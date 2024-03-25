using System;
using System.Linq.Expressions;
using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.User;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.User.Request;
using Blog_Page.Persistance.Context;
using Blog_Page.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.Service.Services
{
    public class UserService<T> : IUserService
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public UserService(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<AppUser> CheckUserAsync(CheckUserDto dto)
        //{

        //}

        public async Task CreateAsync(CreateUserDto dto)
        {
            var entity = _mapper.Map<AppUser>(dto);
            await _context.Set<AppUser>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserListDto dto)
        {
            var deletedEntity = _mapper.Map<AppUser>(dto);
            _context.Set<AppUser>().Remove(deletedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserListDto> FindAsync(int id)
        {
            var entity = GetByFilterAsync(x => x.ID == id);
            var mappedData = _mapper.Map<UserListDto>(entity);
            return mappedData;
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await _context.Set<AppUser>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<AppUser> GetAsync(int id)
        {
            var entity = await _context.Set<AppUser>().FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(UpdateUserDto dto)
        {
            var entity = _mapper.Map<AppUser>(dto);
            _context.Set<AppUser>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserListDto>> GetListAsync()
        {
            var list = await _context.Set<AppUser>().AsNoTracking().ToListAsync();
            return _mapper.Map<List<UserListDto>>(list);
        }
    }
}

