using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.ID);

            builder.HasMany(o => o.Employees)
                .WithOne(e => e.Office)
                .HasForeignKey(e => e.OfficeID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.City)
                .IsRequired();

            builder.Property(o => o.Country)
                 .IsRequired();

            builder.Property(o => o.Headquarters)
                 .IsRequired();

            builder.Property(o => o.Street)
                 .IsRequired();

            builder.Property(o => o.StreetNumber)
                 .IsRequired();
        }
    }
}
