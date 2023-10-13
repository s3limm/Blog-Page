using Blog_Page.Models;
using System.Linq.Expressions;

namespace Blog_Page.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Introduction of Methods

        //Getting Lists
        List<T> GetAllList();

        //Getting Actives

        //Finding Method
        T GetByID(int id);

        //Insert Method
        void Insert(T item);
        //Delete Method
        void Delete(int id);
        //Update Method 
        void Update(T item);
        //Any Method
        bool Any(Expression<Func<T, bool>> expression);
        //Default Method
        T Default(Expression<Func<T, bool>> expression);
    }
}
