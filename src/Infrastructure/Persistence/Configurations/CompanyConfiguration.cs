using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company> 
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.CellPhone)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Email)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.WebSite)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}