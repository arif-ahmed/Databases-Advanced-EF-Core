﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Writer : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }
    [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
    public string? Pseudonym { get; set; }
    public virtual ICollection<Song> Songs { get; set; } = new Collection<Song>();
}
