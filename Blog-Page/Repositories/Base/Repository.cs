using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using Blog_Page.API.Persistance.Context;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.Repositories.Base
{
    public class Repository<T> : IRepositoryUI<T> where T : BaseEntity, new()
    {
        private readonly ApiDbContext _context;

        public Repository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllList()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            var data =  await _context.Set<T>().FindAsync(id);
            return (data);
        }
    }
}
