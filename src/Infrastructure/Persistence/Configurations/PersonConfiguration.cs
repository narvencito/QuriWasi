using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person> 
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.LastName)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Address)
                .HasMaxLength(200);
            builder.Property(t => t.Age)
                .IsRequired();
            builder.Property(t => t.Email)
                .HasMaxLength(200);
            builder.Property(t => t.Phone)
                .HasMaxLength(14);

        }
    }
}