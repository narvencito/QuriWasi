using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType> 
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Type)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}