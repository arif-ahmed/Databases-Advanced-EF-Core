using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data;
public class MusicHubDbContext : DbContext
{
    public MusicHubDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Song> Songs { get; set; }
    public DbSet<Performer> Performers { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<SongPerformer> SongsPerformers { get; set; }
}
