using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> 
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        
        }
    }
}