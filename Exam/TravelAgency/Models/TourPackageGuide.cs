using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models;
public class TourPackageGuide : BaseEntity
{
    [Required]
    public int TourPackageId { get; set; }
    public TourPackage? TourPackage { get; set; }
    [Required]
    public int GuideId { get; set; }
    public Guide? Guide { get; set; }
}
