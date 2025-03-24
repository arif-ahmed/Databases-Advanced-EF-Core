using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Importer.Contracts;
using Newtonsoft.Json.Linq;

namespace MusicHub.Importer;
public class JsonDataImporter : IImporter
{
    private readonly MusicHubDbContext _dbContext;
    private readonly string _filePath;
    public JsonDataImporter(MusicHubDbContext dbContext, string filePath)
    {
        _dbContext = dbContext;
        _filePath = filePath;
    }

    public void Import()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();

        string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imports", "import.json");
        string json = File.ReadAllText(_filePath);
        JObject jObject = JObject.Parse(json);

        AddEntitiesFromJson(jObject, "Writer", _dbContext.Writers);
        AddEntitiesFromJson(jObject, "Producer", _dbContext.Producers);
        AddEntitiesFromJson(jObject, "Album", _dbContext.Albums);
        AddEntitiesFromJson(jObject, "Song", _dbContext.Songs);
        AddEntitiesFromJson(jObject, "Performer", _dbContext.Performers);
        AddEntitiesFromJson(jObject, "SongPerformer", _dbContext.SongsPerformers);

        _dbContext.SaveChanges();
    }

    private void AddEntitiesFromJson<T>(JObject jObject, string key, DbSet<T> dbSet) where T : class
    {
        var items = jObject[key]?.ToObject<List<T>>();
        dbSet.AddRange(items ?? new List<T>());
    }
}
