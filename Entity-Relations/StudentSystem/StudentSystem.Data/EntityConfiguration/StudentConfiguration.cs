using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Models;

namespace StudentSystem.Data.EntityConfiguration
{
    public class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.StudentId);

            builder.Property(student => student.Name).HasMaxLength(100).IsUnicode();
            builder.Property(student => student.PhoneNumber).HasColumnType("CHAR(10)").IsUnicode(false).IsRequired(false);
            builder.Property(student => student.Birthday).IsRequired(false);

            builder.HasMany(std => std.CourseEnrollments).WithOne(sc => sc.Student).HasForeignKey(sc => sc.StudentId);
        }
    }
}