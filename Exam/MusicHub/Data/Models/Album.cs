using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Album : BaseEntity
{
    [Required]
    [MaxLength(40)]
    public string? Name { get; set; }

    [Required]
    public DateOnly ReleaseDate { get; set; }

    public decimal Price => Songs.Sum(s => s.Price);

    public int ProducerId { get; set; }
    public Producer Producer { get; set; }

    public ICollection<Song> Songs { get; set; } = new Collection<Song>();
}
