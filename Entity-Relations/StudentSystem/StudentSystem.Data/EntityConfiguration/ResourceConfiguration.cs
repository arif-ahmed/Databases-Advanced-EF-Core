using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Models;

namespace StudentSystem.Data.EntityConfiguration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(resource => resource.ResourceId);

            builder.Property(resource => resource.Name).HasMaxLength(50).IsUnicode();
            builder.Property(resource => resource.Url).IsUnicode().IsRequired(false);

            builder.HasOne(res => res.Course)
                .WithMany(course => course.Resources)
                .HasForeignKey(course => course.CourseId);
        }
    }
}