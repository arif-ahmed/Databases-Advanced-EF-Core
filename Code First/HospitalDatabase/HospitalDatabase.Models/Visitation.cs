using System;

namespace HospitalDatabase.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int DoctorId { get; set; }
        public int patientId { get; set; }

        // Navigation Properties
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
