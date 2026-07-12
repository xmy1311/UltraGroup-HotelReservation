using Microsoft.EntityFrameworkCore;
using HotelService.Domain.Entities;

namespace HotelService.Infrastructure.Persistence
{
    public  class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext(options)
    {
        public DbSet<HotelEntity> Hotels => Set<HotelEntity>();

        public DbSet<RoomEntity> Rooms => Set<RoomEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);
        }
    }
}
