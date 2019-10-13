namespace HospitalDatabase.Models
{
    public class Diagnose
    {
        public int DiagnoseId { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public int PatientId { get; set; }

        // Navigation Properties
        public Patient Patient { get; set; }
    }
}
