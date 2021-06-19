using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation> 
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.DateIn)
                .IsRequired();
            builder.Property(t => t.DateOut)
                .IsRequired();
            builder.Property(t => t.NumberAdult)
                .IsRequired();
            builder.Property(t => t.NumberChild)
                .IsRequired();

        }
    }
}