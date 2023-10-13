using Blog_Page.Configuration;
using Blog_Page.Initializer;
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
                    "Server=.\\SQLEXPRESS;Database=S3limmBlogDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
            modelBuilder.ApplyConfiguration(new Blogs());
            modelBuilder.ApplyConfiguration(new Categories());
            modelBuilder.ApplyConfiguration(new AppUsers());
        }


        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
