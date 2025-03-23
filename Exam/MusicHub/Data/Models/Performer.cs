namespace MusicHub.Data.Models;
public class Performer : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int Age { get; set; }
    public required decimal NetWorth { get; set; }
}
