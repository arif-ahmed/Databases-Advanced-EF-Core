using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models;
public class Booking : BaseEntity
{
    [Required]
    public DateTime BookingDate { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    [Required]
    public int TourPackageId { get; set; }
    public TourPackage? TourPackage { get; set; }
}
