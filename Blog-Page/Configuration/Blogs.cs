using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Page.Configuration
{
    public class Blogs : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            
            //builder.ToTable("Bloglar");
            //builder.Property(x => x.Content).HasColumnName("İçerik");
            //builder.Property(x => x.Title).HasColumnName("Başlık");
            //builder.Property(x => x.Description).HasColumnName("Açıklama");
            //builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            //builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
            //builder.Property(x => x.Status).HasColumnName("Durum");

            //Relational Properties
            builder.HasOne(c => c.Category).WithMany(b=>b.Blog).HasForeignKey(c=>c.CategoryID);


        }
    }
}
