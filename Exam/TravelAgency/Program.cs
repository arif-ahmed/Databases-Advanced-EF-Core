// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

Console.WriteLine("Hello, World!");


var options = new DbContextOptionsBuilder<TravelAgencyDbContext>()
    .UseInMemoryDatabase("TravelAgencyDB") // InMemory Database Name
    .Options;

using (var db = new TravelAgencyDbContext(options))
{
    await db.Customers.AddAsync(new Customer { Email = "arif.ahmed@gmail.com", PhoneNumber = "+8801676256810", FullName = "John Doe" });
    await db.SaveChangesAsync();

    var list =  db.Customers.ToList();
    Console.WriteLine(list.Count);
}