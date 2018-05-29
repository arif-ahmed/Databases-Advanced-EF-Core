using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Data.Configuration.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(emp => new
            {
                emp.FirstName,
                emp.LastName
            });

            builder.Property(emp => emp.FirstName).IsRequired();
            builder.Property(emp => emp.LastName).IsRequired();
            builder.Property(emp => emp.Salary).IsRequired();
        }
    }
}