﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [ForeignKey(nameof(ProducerId))]
    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new Collection<Song>();
}
