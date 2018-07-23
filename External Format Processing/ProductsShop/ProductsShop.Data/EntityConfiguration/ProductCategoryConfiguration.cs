using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShop.Data.EntityConfiguration
{
    class ProductCategoryConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductCategoies).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Category).WithMany(x => x.CategoryProducts).HasForeignKey(x => x.CategoryId);
        }
    }
}
