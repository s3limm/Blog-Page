using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Page.Configuration
{
    public class Categories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Kategoriler");
            builder.Property(x => x.CategoryName).HasColumnName("Kategori Adı");
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            builder.Property(x => x.Status).HasColumnName("Durum");
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
        }
    }
}
