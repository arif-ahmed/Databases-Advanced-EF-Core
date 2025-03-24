using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Producer : BaseEntity
{
    [Required]
    [MaxLength(30)]
    public string? Name { get; set; }
    [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
    public string? Pseudonym { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual ICollection<Album> Albums { get; set; } = new Collection<Album>();
}
