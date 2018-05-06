using System;

namespace StudentSystem.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public DateTime? Birthday { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? RegisteredOn { get; set; }

        // public ICollection<StudentCourse> EnrolledCourses { get; set; }
        // public ICollection<HomeworkSubmission> Homeworks { get; set; }

        public Student()
        {
            //EnrolledCourses = new List<StudentCourse>();
            //Homeworks = new List<HomeworkSubmission>();
        }
    }
}
