using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Models;

namespace StudentSystem.Data.EntityConfiguration
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => new {sc.StudentId, sc.CourseId});

            builder.HasOne(sc => sc.Student)
                .WithMany(std => std.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                .WithMany(course => course.StudentsEnrolled)
                .HasForeignKey(course => course.CourseId);
        }
    }
}