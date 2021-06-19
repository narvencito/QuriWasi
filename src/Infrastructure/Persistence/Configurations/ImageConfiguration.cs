using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image> 
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Url)
                .HasMaxLength(200)
                .IsRequired();
        
        }
    }
}