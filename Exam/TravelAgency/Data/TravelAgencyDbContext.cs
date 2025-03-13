using Microsoft.EntityFrameworkCore;
using TravelAgency.Data.EntityTypeConfigurations;
using TravelAgency.Models;

namespace TravelAgency.Data;
public class TravelAgencyDbContext : DbContext
{
    public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            // optionsBuilder.UseSqlServer("Server=.;Database=TravelAgency;Integrated Security=True");
            optionsBuilder.UseInMemoryDatabase("TravelAgencyDB");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        // base.OnModelCreating(modelBuilder);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Guide> Guides { get; set; }
    public DbSet<TourPackage> TourPackages { get; set; }
    public DbSet<TourPackageGuide> TourPackageGuides { get; set; }
}
