using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Page.Configuration
{
    public class AppUsers : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.ToTable("Kullanıcılar");
            //builder.Property(x => x.userName).HasColumnName("Kullanıcı Adı");
            //builder.Property(x => x.Password).HasColumnName("Şifre");
            //builder.Property(x => x.Email);
            //builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            //builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
            //builder.Property(x => x.Status).HasColumnName("Durum");
        }
    }
}
