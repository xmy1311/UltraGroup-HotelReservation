using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration:  IEntityTypeConfiguration<ReservationEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.RoomId)
                .IsRequired();

            builder.Property(r => r.HotelId)
                .IsRequired();

            builder.Property(r => r.CheckIn)
                .IsRequired(); 
            
            builder.Property(r => r.CheckOut)
                .IsRequired();

            builder.Property(r => r.NumberOfGuests)
                .IsRequired();

            builder.Property(r => r.Status)
                .IsRequired();

            builder.Property(r => r.EmergencyContactName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(r => r.EmergencyContactPhone)
            .HasMaxLength(150)
            .IsRequired();


            builder.Property(r => r.CreatedAt)
                .IsRequired();


            builder.HasMany(r => r.Guests)
           .WithOne(g => g.Reservation)
           .HasForeignKey(g => g.ReservationId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
