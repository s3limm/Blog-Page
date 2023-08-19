﻿using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_Page.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Kullanıcılar");
            builder.Property(x=>x.userName).HasColumnName("Kullanıcı Adı").IsRequired();
            builder.Property(x => x.Password).HasColumnName("Şifre").IsRequired();
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x => x.Status).HasColumnName("Durum");
            builder.Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            builder.Property(x => x.ModifiedDate).HasColumnName("Güncellenme Tarihi");
        }
    }
}
