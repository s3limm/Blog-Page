using Blog_Page.Persistance.Context;
using Blog_Page.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Service.Services
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly BlogDbContext _context;

        public Repository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        { 
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
