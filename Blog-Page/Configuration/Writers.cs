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
            builder.Property(x => x.FirstName).HasColumnName("Adı").IsRequired();
            builder.Property(x => x.LastName).HasColumnName("Soyadı").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            builder.Property(x => x.Status).HasColumnName("Durum");
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
        }
    }
}
