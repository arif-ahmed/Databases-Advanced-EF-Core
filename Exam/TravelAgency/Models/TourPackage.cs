namespace TravelAgency.Models;
public class TourPackage : BaseEntity
{
    public string? PackageNmae { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<Booking> Bookings { get; set; } = new();
    public List<TourPackageGuide> TourPackageGuides { get; set; } = new();
}
