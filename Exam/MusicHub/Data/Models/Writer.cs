using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Writer : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }
    public virtual ICollection<Song> Songs { get; set; } = new Collection<Song>();
}
