using System;

namespace ProductsShop.Model
{
    public class CategoryProduct
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}