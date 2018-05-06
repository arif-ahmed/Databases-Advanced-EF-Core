using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Models;

namespace StudentSystem.Data.EntityConfiguration
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(hw => hw.HomeworkId);

            builder.Property(hw => hw.Content).IsUnicode(false);

            builder.HasOne(hw => hw.Course)
                .WithMany(course => course.HomeworkSubmissions)
                .HasForeignKey(course => course.CourseId);

            builder.HasOne(hw => hw.Student)
                .WithMany(student => student.HomeworkSubmissions)
                .HasForeignKey(student => student.StudentId);
        }
    }
}