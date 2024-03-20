using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Service.Api.Abstract
{
    public interface IRepository<T> where T : class,new()
    {
        Task<List<T>> GetAllListAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
