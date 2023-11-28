using Blog_Page.API.Core.Domain;
using Blog_Page.API.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.API.Persistance.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {

        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
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
            modelBuilder.ApplyConfiguration(new BlogConfigurations());
        }


        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
