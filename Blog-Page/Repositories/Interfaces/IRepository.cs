using Blog_Page.Models;

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
    }
}
