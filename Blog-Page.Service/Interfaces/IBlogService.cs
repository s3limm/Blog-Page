using System;
using System.Linq.Expressions;
using Blog_Page.Domain.BlogPage.Dtos.Blog;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.Blog.Request;
using Blog_Page.Service.Api.Concrete;

namespace Blog_Page.Service.Api.Interfaces
{
	public interface IBlogService
	{
		Task<List<BlogListDto>> GetListAsync();
        Task<Blog> GetByFilterAsync(Expression<Func<Blog, bool>> filter);
        Task<BlogListDto> FindAsync(int id);
		Task CreateAsync(CreateBlogDto dto);
		Task UpdateAsync(UpdateBlogDto dto);
        Task DeleteAsync(BlogListDto dto);
    }
}

