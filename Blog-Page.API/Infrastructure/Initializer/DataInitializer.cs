using Blog_Page.API.Core.Application.Enums;
using Blog_Page.API.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog_Page.API.Infrastructure.Initializer
{
    public class DataInitializer
    {
        public static void Seed(ModelBuilder builder)
        {
            string password = BCrypt.Net.BCrypt.HashPassword("123456");

            builder.Entity<AppUser>().HasData(new AppUser() { ID = 1, userName = "Admin", Password = password, 
                AppRoleId = 1, Email = "selimemrem@gmail.com" });

            builder.Entity<AppRole>().HasData(new AppRole() { Id = 2,Definition = "User",Status = Status.Inserted});

            builder.Entity<AppRole>().HasData(new AppRole() { Id = 1,Definition = "Admin" , Status = Status.Inserted});
        }
    }
}
