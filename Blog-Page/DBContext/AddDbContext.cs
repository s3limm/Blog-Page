using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.DBContext
{
    public class AddDbContext : DbContext
    {
        public AddDbContext()
        {

        }
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
