using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelService.Domain.Entities;

namespace HotelService.Infrastructure.Persistence.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<HotelEntity>
    {
        public void Configure(EntityTypeBuilder<HotelEntity> builder)
        {
            builder.ToTable("Hotels");
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name).IsRequired().HasMaxLength(150);
            builder.Property(h => h.Address).IsRequired().HasMaxLength(250);
            builder.Property(h => h.City).IsRequired().HasMaxLength(100);
            builder.Property(h => h.Description).HasMaxLength(500);
            builder.Property(h => h.IsEnabled).IsRequired();
            builder.Property(h => h.CreatedAt).IsRequired();

        }
    }
}
