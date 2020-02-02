using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.ID);

            builder.HasMany(c => c.Offices).
                WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .IsRequired();
        }
    }
}
