using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.ID);

            builder.Property(e => e.ExperienceLevel)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.Salary)
                .IsRequired();

            builder.Property(e => e.StartingDate)
                .IsRequired();

            builder.Property(e => e.VacationDays)
                .IsRequired();
        }
    }
}
