using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.Blog;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.Blog.Request;
using Blog_Page.Persistance.Context;
using Blog_Page.Service.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Service.Api.Concrete
{
    public class BlogService<T> : IBlogService
    {
        public readonly BlogContext _context;
        private readonly IMapper _mapper;

        public BlogService(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BlogListDto>> GetListAsync()
        {
            var list = await _context.Set<Blog>().AsNoTracking().ToListAsync();
            return _mapper.Map<List<BlogListDto>>(list);
        }

        public async Task CreateAsync(CreateBlogDto dto)
        {
            var entity = _mapper.Map<Blog>(dto);
            await _context.Set<Blog>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BlogListDto dto)
        {
            var deletedEntity = _mapper.Map<Blog>(dto);
            _context.Set<Blog>().Remove(deletedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<BlogListDto> GetByFilterAsync(int id)
        {
            var entity = await _context.Set<Blog>().FindAsync(id);
            var mappedEntity = _mapper.Map<BlogListDto>(entity);
            return mappedEntity;
        }

       
        public async Task UpdateAsync(UpdateBlogDto dto)
        {
            var entity = _mapper.Map<Blog>(dto);
            _context.Set<Blog>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Blog> GetByFilterAsync(Expression<Func<Blog, bool>> filter)
        {
            return await _context.Set<Blog>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<BlogListDto> FindAsync(int id)
        {
            var entity = await GetByFilterAsync(x => x.ID == id);
            var mappedData = _mapper.Map<BlogListDto>(entity);
            return mappedData;
        }
    }
}
