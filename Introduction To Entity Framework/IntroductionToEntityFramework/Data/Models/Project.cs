﻿using System;
using System.Collections.Generic;

namespace IntroductionToEntityFramework.Data.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
