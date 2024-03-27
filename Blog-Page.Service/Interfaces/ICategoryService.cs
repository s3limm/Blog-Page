using System;
using System.Linq.Expressions;
using Blog_Page.Domain.BlogPage.Dtos.Category;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.Category.Request;

namespace Blog_Page.Service.Interfaces
{
	public interface ICategoryService<T>
	{
		Task<List<CategoryListDto>> GetListAsync();
		Task<CategoryListDto> FindAsync(int id);
        Task<Category> GetByFilterAsync(Expression<Func<Category, bool>> filter);
        Task CreateAsync(CreateCategoryDto dto);
		Task UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(CategoryListDto dto);
	}
}

