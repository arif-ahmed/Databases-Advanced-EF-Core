// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using TravelAgency.Data;
using TravelAgency.Models;
using TravelAgency.Models.Enums;

Console.WriteLine("Hello, World!");


var options = new DbContextOptionsBuilder<TravelAgencyDbContext>()
    .UseInMemoryDatabase("TravelAgencyDB") // InMemory Database Name
    .Options;

using (var db = new TravelAgencyDbContext(options))
{
    //var customers = db.Customers
    //    .Where(c => c.Bookings.Any(b => b.TourPackage != null && b.TourPackage.PackageName == "Horse Riding Tour"))
    //    .OrderByDescending(c => c.Bookings.Count)
    //    .ThenBy(c => c.FullName)
    //    .Select(c => new 
    //    {
    //        c.FullName,
    //        c.PhoneNumber,
    //        Bookings = c.Bookings                
    //            .Select(b => new
    //            {
    //                b.TourPackage.PackageName,
    //                b.BookingDate
    //            })
    //    });    

    db.Customers.Join(db.Bookings, c => c.Id, b => b.CustomerId, (c, b) => new { c, b })
        .Where(x => x.b.TourPackage != null && x.b.TourPackage.PackageName == "Horse Riding Tour")
        .GroupBy(x => x.c)
        .OrderByDescending(x => x.Count())
        .ThenBy(x => x.Key.FullName)
        .Select(x => new
        {
            x.Key.FullName,
            x.Key.PhoneNumber,
            Bookings = x.Select(b => new
            {
                b.b.TourPackage.PackageName,
                b.b.BookingDate
            })
        });

    var customers = db.Guides
        .Include(g => g.TourPackageGuides) // Ensure TourPackageGuides is loaded
            .ThenInclude(tpg => tpg.TourPackage) // Ensure TourPackage is loaded
        .Where(g => g.Language == Language.Spanish)
        .OrderByDescending(g => g.TourPackageGuides.Any() ? g.TourPackageGuides.Count() : 0) // Ensure it's not null
        .ThenBy(g => g.FullName)
        .Select(c => new
        {
            c.FullName,
            TourPackages = c.TourPackageGuides
                .Where(tpg => tpg.TourPackage != null) // Ensure TourPackage is not null
                .OrderByDescending(tpg => tpg.TourPackage.Price)
                .ThenBy(tpg => tpg.TourPackage.PackageName)
                .Select(tpg => new
                {
                    PackageName = tpg.TourPackage.PackageName,
                    Description = tpg.TourPackage.Description ?? "No Description",
                    Price = tpg.TourPackage.Price
                }).ToList()
        })
        .ToList(); // Ensure query execution before returning

}
string GetProjectDirectory()
{
    var currentDirectory = Directory.GetCurrentDirectory();
    var directoryName = Path.GetFileName(currentDirectory);
    var relativePath = directoryName.StartsWith("net9.0") ? @"../../../" : string.Empty;

    return relativePath;
}