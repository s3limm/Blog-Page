//using Blog_Page.Configuration;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new Blogs());
            //modelBuilder.ApplyConfiguration(new AppUsers());
            //modelBuilder.ApplyConfiguration(new Writers());
            //modelBuilder.ApplyConfiguration(new Categories());

            ////AppUser
            //modelBuilder.Entity<AppUser>().ToTable("Kullanıcılar");
            //modelBuilder.Entity<AppUser>().Property(x => x.userName).HasColumnName("Kullanıcı Adı").IsRequired();
            //modelBuilder.Entity<AppUser>().Property(x => x.Password).HasColumnName("Şifre").IsRequired();
            //modelBuilder.Entity<AppUser>().Property(x => x.Email).IsRequired();
            //modelBuilder.Entity<AppUser>().Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            //modelBuilder.Entity<AppUser>().Property(x => x.Status).HasColumnName("Durum");
            //modelBuilder.Entity<AppUser>().Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");

            ////Blog
            //modelBuilder.Entity<Blog>().ToTable("Bloglar");
            //modelBuilder.Entity<Blog>().Property(x => x.Title).HasColumnName("Başlık");
            //modelBuilder.Entity<Blog>().Property(x => x.Description).HasColumnName("Açıklama");
            //modelBuilder.Entity<Blog>().Property(x => x.Content).HasColumnName("İçerik");
            //modelBuilder.Entity<Blog>().Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            //modelBuilder.Entity<Blog>().Property(x => x.Status).HasColumnName("Durum");
            //modelBuilder.Entity<Blog>().Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
            ////Relational Properties
            ////modelBuilder.Entity<Blog>().HasOne(w => w.Writer).WithMany(b => b.Blog).HasForeignKey(w => w.WriterID);
            ////modelBuilder.Entity<Blog>().HasOne(c => c.Category).WithMany(b => b.Blog).HasForeignKey(c => c.CategoryID);

            ////Category
            //modelBuilder.Entity<Category>().ToTable("Kategoriler");
            //modelBuilder.Entity<Category>().Property(x => x.CategoryName).HasColumnName("Kategori Adı");
            //modelBuilder.Entity<Category>().Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            //modelBuilder.Entity<Category>().Property(x => x.Status).HasColumnName("Durum");
            //modelBuilder.Entity<Category>().Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");

            ////Writer
            //modelBuilder.Entity<Writer>().ToTable("Yazarlar");
            //modelBuilder.Entity<Writer>().Property(x => x.FirstName).HasColumnName("Adı").IsRequired();
            //modelBuilder.Entity<Writer>().Property(x => x.LastName).HasColumnName("Soyadı").IsRequired();
            //modelBuilder.Entity<Writer>().Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            //modelBuilder.Entity<Writer>().Property(x => x.Status).HasColumnName("Durum");
            //modelBuilder.Entity<Writer>().Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
