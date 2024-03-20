using Blog_Page.Persistance.Context;
using Blog_Page.Service.Application.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Service.Application.Concrete
{
    public class ApplicationService<T> : IApplicationService<T> where T : class, new()
    {
        private readonly BlogContext _context;

        public ApplicationService(BlogContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);
            return (data);
        }
    }
}
