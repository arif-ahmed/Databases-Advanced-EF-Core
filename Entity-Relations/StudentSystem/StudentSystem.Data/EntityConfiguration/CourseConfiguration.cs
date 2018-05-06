using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Models;

namespace StudentSystem.Data.EntityConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(course => course.CourseId);

            builder.Property(course => course.Name).HasMaxLength(80).IsUnicode();
            builder.Property(course => course.Description).IsUnicode().IsRequired(false);

            builder.HasMany(course => course.StudentsEnrolled)
                .WithOne(es => es.Course)
                .HasForeignKey(es => es.CourseId);

            builder.HasMany(course => course.Resources)
                .WithOne(resource => resource.Course)
                .HasForeignKey(res => res.CourseId);

            builder.HasMany(course => course.HomeworkSubmissions)
                .WithOne(hs => hs.Course)
                .HasForeignKey(hs => hs.CourseId);
        }
    }
}