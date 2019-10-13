﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        // Navigation Properties
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
