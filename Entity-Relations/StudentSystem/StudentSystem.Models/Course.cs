using System;
using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }

        public ICollection<StudentCourse> EnrolledStudents { get; set; }
        public ICollection<HomeworkSubmission> Homeworks { get; set; }

        public Course()
        {
            EnrolledStudents = new List<StudentCourse>();
            Homeworks = new List<HomeworkSubmission>();
        }
    }
}