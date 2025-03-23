using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
