using System;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App
{
    class Starpup
    {
        static void Main(string[] args)
        {
            using (var db = new BillsPaymentSystemContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
