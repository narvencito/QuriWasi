using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class EventualityConfiguration : IEntityTypeConfiguration<Eventuality> 
    {
        public void Configure(EntityTypeBuilder<Eventuality> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}