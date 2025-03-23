using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models;
public class TourPackage : BaseEntity
{
    [Required]
    [StringLength(40, MinimumLength = 2, ErrorMessage = "PackageName must be minimum 4 character and maximum 40 charaters in length")]
    public string? PackageName { get; set; }
    public string? Description { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive decimal value.")]
    public decimal Price { get; set; }
    public List<Booking> Bookings { get; set; } = new();
    public List<TourPackageGuide> TourPackageGuides { get; set; } = new();
}
