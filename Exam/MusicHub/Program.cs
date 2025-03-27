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

                // 3. Songs Above Given Duration
                db.Songs.Where(s => s.Duration.TotalMinutes > 4)
                    .Include(s => s.SongPerformers)
                    .Include(s => s.Writer)
                    .Include(s => s.Album.Producer)
                    .Select(s => new 
                    {
                        s.Name,
                        Writer = s.Writer.Name,
                        Performer = s.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).ToList(),
                        AlbumProducer = s.Album.Producer.Name,
                        DurationFormat = s.Duration.ToString("c")
                    })
                    .OrderBy(s => s.Name)
                    .ThenBy(s => s.Writer);
            }
        }
    }
}
