using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType> 
    {
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Type)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}