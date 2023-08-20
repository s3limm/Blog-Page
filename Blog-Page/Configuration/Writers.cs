using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Page.Configuration
{
    public class Writers : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.ToTable("Yazarlar");
            builder.Property(x => x.FirstName).HasColumnName("Adı");
            builder.Property(x => x.LastName).HasColumnName("Soyadı");
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
            builder.Property(x => x.Status).HasColumnName("Durum");
        }
    }
}
