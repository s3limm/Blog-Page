using Microsoft.EntityFrameworkCore;

namespace Blog_Page.DBContext
{
    public class LogInDBContext : DbContext
    {
        public LogInDBContext()
        {
        }

        public LogInDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<LogIn> logIn { get; set; }
}
}
