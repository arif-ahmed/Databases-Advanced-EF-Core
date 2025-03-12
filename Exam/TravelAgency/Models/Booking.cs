namespace TravelAgency.Models;
public class Booking : BaseEntity
{
    public DateTime BookingDate { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int TourPackageId { get; set; }
    public TourPackage? TourPackage { get; set; }
}
