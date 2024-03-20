using Blog_Page.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Persistance.Middleware
{
    public class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            string password = BCrypt.Net.BCrypt.HashPassword("123456");

            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                ID = 1,
                userName = "Admin",
                Password = password,
                AppRoleId = 1,
                Email = "selimemrem@gmail.com"
            });

            modelBuilder.Entity<AppRole>().HasData(new AppRole() { Id = 2, Definition = "User", Status = Status.Inserted });

            modelBuilder.Entity<AppRole>().HasData(new AppRole() { Id = 1, Definition = "Admin", Status = Status.Inserted });
        }
    }
}
