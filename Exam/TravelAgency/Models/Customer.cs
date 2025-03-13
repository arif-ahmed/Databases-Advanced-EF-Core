using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models;
public class Customer : BaseEntity
{
    [Required]
    [StringLength(60, MinimumLength = 4)]
    public string? FullName { get; set; }

    [Required]

    public string? Email { get; set; }

    [Required]
    [RegularExpression(@"^\+\d{12}$", ErrorMessage = "Phone number must start with '+' followed by 12 digits.")]
    public string? PhoneNumber { get; set; }
    public List<Booking> Bookings { get; set; } = new();
}
