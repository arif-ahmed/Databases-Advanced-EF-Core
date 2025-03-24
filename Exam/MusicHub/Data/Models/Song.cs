using MusicHub.Data.Models.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models;
public class Song : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public required string Name { get; set; }
    [Required]
    public required TimeSpan Duration { get; set; }
    [Required]
    public required DateOnly CreatedOn { get; set; }
    [Required]
    public Genre Genre { get; set; }
    public int AlbumId { get; set; }
    [ForeignKey(nameof(AlbumId))]
    public virtual Album? Album { get; set; }
    [Required]
    public int WriterId { get; set; }
    [ForeignKey(nameof(WriterId))]
    public virtual Writer? Writer { get; set; }
    [Required]
    public decimal Price { get; set; }
    public virtual ICollection<SongPerformer> SongPerformers { get; set; } = new Collection<SongPerformer>();
}