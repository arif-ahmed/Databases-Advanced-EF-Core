using System.ComponentModel.DataAnnotations;
using TravelAgency.Models.Enums;

namespace TravelAgency.Models;
public class Guide : BaseEntity
{
    [Required]
    [StringLength(60, MinimumLength = 4)]
    public string? FullName { get; set; }
    [Required]
    public Language Language { get; set; }
    public List<TourPackageGuide> TourPackageGuides { get; set; } = new();
}
