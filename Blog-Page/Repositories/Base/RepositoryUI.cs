using Blog_Page.Domain.Entities;
using Blog_Page.Models;
using Blog_Page.Persistance.Context;
using Blog_Page.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.Repositories.Base
{
    public class RepositoryUI<T> : IRepositoryUI<T> where T : BaseEntity, new()
    {
        private readonly BlogDbContext _context;

        public RepositoryUI(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            var data =  await _context.Set<T>().FindAsync(id);
            return (data);
        }
    }
}
