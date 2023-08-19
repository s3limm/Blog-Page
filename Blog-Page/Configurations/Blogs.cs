using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Page.Configurations
{
    public class Blogs : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Bloglar");
            builder.Property(x=>x.Title).HasColumnName("Başlık").IsRequired();
            builder.Property(x => x.Description).HasColumnName("Açıklama").IsRequired();
            builder.Property(x => x.Content).HasColumnName("İçerik").IsRequired();
            builder.Property(x => x.Status).HasColumnName("Durum");
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
            builder.HasOne(c => c.Category).WithMany(b => b.Blog).HasForeignKey(b => b.CategoryID);
            builder.HasOne(w=>w.Writer).WithMany(b=>b.Blog).HasForeignKey(b => b.WriterID);
        }
    }
}
