using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Page.Configurations
{
    public class Categorys : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Kategori");
            builder.Property(x => x.CategoryName).HasColumnName("Kategori Adı").IsRequired();
            builder.Property(x => x.Status).HasColumnName("Durum");
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
        }
    }
}
