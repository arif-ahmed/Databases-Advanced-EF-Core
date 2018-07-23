

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsShop.Model;

namespace ProductsShop.Data.EntityConfiguration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ProductCategoies).WithOne(y => y.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
