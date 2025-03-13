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
    await db.Customers.AddAsync(new Customer { FullName = "John Doe" });
    await db.SaveChangesAsync();
}