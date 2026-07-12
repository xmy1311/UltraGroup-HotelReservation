using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure.Persistence.Configurations
{
    public class GuestConfiguration: IEntityTypeConfiguration<GuestEntity>
    {
        public void Configure(EntityTypeBuilder<GuestEntity> builder)
        {
            builder.ToTable("Guests");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.BirthDate)
                .IsRequired();

            builder.Property(g => g.Gender)
                .IsRequired();

            builder.Property(g => g.DocumentType)
               .IsRequired();

            builder.Property(g => g.DocumentNumber)
               .IsRequired();

            builder.Property(g => g.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(g => g.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(g => g.Reservation)
                .WithMany(r=> r.Guests)
                .HasForeignKey(g => g.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
