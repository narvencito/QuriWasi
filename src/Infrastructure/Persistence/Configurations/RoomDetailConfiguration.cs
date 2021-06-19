using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class RoomDetailConfiguration : IEntityTypeConfiguration<RoomDetail> 
    {
        public void Configure(EntityTypeBuilder<RoomDetail> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.NumberOccupants)
                .IsRequired();
        
        }
    }
}