using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).HasMaxLength(25).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(25).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(30).IsRequired();

            builder.HasIndex(u => u.UserName).IsUnique();
        }
    }
}
