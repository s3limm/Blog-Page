using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Service.Application.Abstract
{
    public interface IApplicationService<T> where T : class,new()
    {
        Task<List<T>> GetListAsync();

        Task<T> GetByIDAsync(int id);
    }
}
