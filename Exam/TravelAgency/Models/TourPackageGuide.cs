namespace TravelAgency.Models;
public class TourPackageGuide : BaseEntity
{
    public int TourPackageId { get; set; }
    public TourPackage? TourPackage { get; set; }
    public int GuideId { get; set; }
    public Guide? Guide { get; set; }
}
