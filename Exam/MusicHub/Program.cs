using Microsoft.EntityFrameworkCore;
using MusicHub.Data;

namespace MusicHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Test();

        }

        static void Test() 
        {
            var options = new DbContextOptionsBuilder<MusicHubDbContext>()
                .UseInMemoryDatabase("MusicHubDB")
                .Options;
            using (var db = new MusicHubDbContext(options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}
