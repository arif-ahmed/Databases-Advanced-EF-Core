using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Models;

namespace StudentSystem.Data.EntityConfiguration
{
    public class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(std => std.StudentId);

            builder.Property(std => std.Name).HasMaxLength(100).IsRequired().IsUnicode();
            builder.Property(std => std.PhoneNumber).IsUnicode(false).IsRequired(false).HasColumnType("CHAR(10)");
            builder.Property(std => std.Birthday).IsRequired(false);
        }
    }
}