using System;
using System.Linq.Expressions;
using Blog_Page.Domain.BlogPage.Dtos.Blog;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.Blog.Request;

namespace Blog_Page.Service.Interfaces
{
	public interface IBlogService<T>
	{
		Task<List<BlogListDto>> GetListAsync();
        Task<Blog> GetByFilterAsync(Expression<Func<Blog, bool>> filter);
        Task<BlogListDto> FindAsync(int id);
		Task CreateAsync(CreateBlogDto dto);
		Task UpdateAsync(UpdateBlogDto dto);
        Task DeleteAsync(BlogListDto dto);
    }
}

