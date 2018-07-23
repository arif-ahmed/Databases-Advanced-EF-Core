using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShop.Data.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(15).IsRequired();

            builder.HasMany(x => x.CategoryProducts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
