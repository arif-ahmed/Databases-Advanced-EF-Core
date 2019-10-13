using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Models
{
    public class Medicament
    {
        public int MedicamentId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
