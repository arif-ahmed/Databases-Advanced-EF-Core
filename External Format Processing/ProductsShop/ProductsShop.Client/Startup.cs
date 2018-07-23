using System;
using ProductsShop.Data;
using Newtonsoft.Json;

namespace ProductsShop.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            using(var db = new ProductShopDbContext())
            {
                db.Database.EnsureCreated();

                JsonConvert
            }
            Console.WriteLine("Hello World!");
        }
    }
}
