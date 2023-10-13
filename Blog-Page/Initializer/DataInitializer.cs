using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.Initializer
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            string passWord = BCrypt.Net.BCrypt.HashPassword("pl2107980LP");
            modelBuilder.Entity<AppUser>().HasData(
              new AppUser() { ID = 1, userName = "s3limm", Password = passWord, Role = Enums.Role.Admin ,Email = "selimemrem@gmail.com"});
        }
    }
}
