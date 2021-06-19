using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuriWasi.Infrastructure.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room> 
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.RoomCode)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.RoomNumber)
                .IsRequired();

            builder.Property(t => t.NickName)
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasMaxLength(1000)
                .IsRequired();

        }
    }
}