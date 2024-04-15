using System;
using System.Linq.Expressions;
using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.Category;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.Category.Request;
using Blog_Page.Persistance.Context;
using Blog_Page.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public CategoryService(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> GetListAsync()
        {
            var list = await _context.Set<Category>().AsNoTracking().ToListAsync();
            return _mapper.Map<List<CategoryListDto>>(list);
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _context.Set<Category>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CategoryListDto dto)
        {
            var deletedEntity = _mapper.Map<Category>(dto);
            _context.Set<Category>().Remove(deletedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoryListDto> FindAsync(int id)
        {
            var entity = GetByFilterAsync(x => x.ID == id);
            var mappedData = _mapper.Map<CategoryListDto>(entity);
            return mappedData;
        }

        public async Task<Category> GetByFilterAsync(Expression<Func<Category, bool>> filter)
        {
            return await _context.Set<Category>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<CategoryListDto> GetAsync(int id)
        {
            var entity = await _context.Set<Category>().FindAsync(id);
            var mappedEntity = _mapper.Map<CategoryListDto>(entity);
            return mappedEntity;
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            _context.Set<Category>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

