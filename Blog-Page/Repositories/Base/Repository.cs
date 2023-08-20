using Blog_Page.DBContext;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog_Page.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        AddDbContext _db;
        protected DbSet<T> table;
        public Repository(AddDbContext db)
        {
            _db = db;
            table = _db.Set<T>();
        }
        private void Save()
        {
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = GetByID(id);
            item.Status = Enums.Status.Deleted;
            item.ModifiedDate = DateTime.Now;
            Save();
        }

        public List<T> GetAllList()
        {
            return table.ToList();
        }

        public T GetByID(int id)
        {
            return table.Find(id);
        }

        public void Insert(T item)
        {
            table.Add(item);
            Save();
        }

        public List<T> ListActives()
        {
            return table.Where(x => x.Status != Enums.Status.Deleted).ToList();
        }

        public void Update(T item)
        {
            item.Status = Enums.Status.Updated;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            Save();
        }
    }
}
