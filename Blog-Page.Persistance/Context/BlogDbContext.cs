using Blog_Page.Domain.Entities;
using Blog_Page.Persistance.Configurations;
using Blog_Page.Persistance.Middleware;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Persistance.Context
{
	public class BlogDbContext:DbContext
	{
		public BlogDbContext()
		{

		}

		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseSqlServer(
					"Server=.\\SQLEXPRESS;Database=blogdb;Trusted_Connection=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			DataInitializer.Seed(modelBuilder);
			modelBuilder.ApplyConfiguration(new AppUserConfiguration());
			modelBuilder.ApplyConfiguration(new BlogConfiguration());
		}

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<AppRole> AppRoles { get; set; }
	}
}
