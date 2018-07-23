using System;
using System.Collections.Generic;

namespace ProductsShop.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid SellerId { get; set; }

        public ICollection<CategoryProduct> ProductCategoies { get; set; }
    }
}