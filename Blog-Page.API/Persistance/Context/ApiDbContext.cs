using Blog_Page.API.Core.Domain;
using Blog_Page.API.Infrastructure.Initializer;
using Blog_Page.API.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.API.Persistance.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {

        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLEXPRESS;Database=BlogPageApiDb;Trusted_Connection=True;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
            modelBuilder.ApplyConfiguration(new BlogConfigurations());
            modelBuilder.ApplyConfiguration(new AppUserConfigurations());
        }


        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
