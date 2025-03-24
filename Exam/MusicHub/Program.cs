using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Data.Models;
using MusicHub.Importer;
using Newtonsoft.Json.Linq;

namespace MusicHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<MusicHubDbContext>().UseInMemoryDatabase("MusicHubDB").Options;
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imports", "import.json");

            using (var db = new MusicHubDbContext(options))
            {
                JsonDataImporter importer = new JsonDataImporter(db, jsonPath);
                importer.Import();
            }
        }
    }
}
