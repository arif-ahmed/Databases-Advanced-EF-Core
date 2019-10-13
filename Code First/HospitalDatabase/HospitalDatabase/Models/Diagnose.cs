﻿
using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Models
{
    public class Diagnose
    {
        public int DiagnoseId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        public int PatientId { get; set; }

        // Navigation Properties
        public Patient Patient { get; set; }
    }
}
