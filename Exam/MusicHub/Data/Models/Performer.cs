using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Performer : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public required string FirstName { get; set; }
    [Required]
    [MaxLength(20)]
    public required string LastName { get; set; }
    [Required]
    public required int Age { get; set; }
    [Required]
    public required decimal NetWorth { get; set; }
    public virtual ICollection<SongPerformer> PerformerSongs { get; set; } = new Collection<SongPerformer>();
}
