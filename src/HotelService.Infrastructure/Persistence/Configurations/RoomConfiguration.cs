using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HotelService.Infrastructure.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Number)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.Type)
                .IsRequired();

            builder.Property(r => r.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
                

            builder.Property(r => r.Taxes)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(r => r.Location)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Capacity)
                .IsRequired();

            builder.Property(r => r.IsEnabled)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.HasOne(r=> r.Hotel)
                .WithMany(h=>h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => new { r.HotelId, r.Number })
                .HasDatabaseName("IX_Rooms_HotelId_Number")
                .IsUnique();

        }
    }
}
