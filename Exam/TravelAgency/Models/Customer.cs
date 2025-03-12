namespace TravelAgency.Models;
public class Customer : BaseEntity
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Booking> Bookings { get; set; } = new();
}
