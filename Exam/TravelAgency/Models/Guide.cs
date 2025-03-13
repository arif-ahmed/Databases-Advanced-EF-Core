using TravelAgency.Models.Enums;

namespace TravelAgency.Models;
public class Guide : BaseEntity
{
    public string? FullName { get; set; }
    public Language Language { get; set; }
    public List<TourPackageGuide> TourPackageGuides { get; set; } = new();
}
