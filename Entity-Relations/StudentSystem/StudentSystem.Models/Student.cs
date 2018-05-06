using System;
using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public DateTime? Birthday { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? RegisteredOn { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public Student()
        {
            CourseEnrollments = new HashSet<StudentCourse>();
            HomeworkSubmissions = new HashSet<Homework>();
        }
    }
}
