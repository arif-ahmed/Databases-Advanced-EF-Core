using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

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
    public Album Album { get; set; }
    public int WriterId { get; set; }
    public Writer Writer { get; set; }
    [Required]
    public decimal Price { get; set; }
    public ICollection<SongPerformer> SongPerformers { get; set; }
}