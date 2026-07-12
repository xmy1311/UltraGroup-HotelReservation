using HotelService.Domain.Entities;
using HotelService.Domain.Interfaces;
using HotelService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.Infrastructure.Repositories
{
    public class RoomRepository(HotelDbContext hotelDbContext) : IRoomRepository
    {
        private readonly HotelDbContext _hotelDbContext = hotelDbContext;

        public async Task AddAsync(RoomEntity room)
        {
            await _hotelDbContext.Rooms.AddAsync(room);
            await _hotelDbContext.SaveChangesAsync();
        }

 
        public async Task<IEnumerable<RoomEntity>> GetByHotelAsync(Guid hotelId)
        {
           return await _hotelDbContext.Rooms
                       .Where(r => r.HotelId == hotelId).ToListAsync();
        }

        public async Task<RoomEntity?> GetByIdAsync(Guid id)
        {
            return await _hotelDbContext.Rooms.FirstOrDefaultAsync(r=> r.Id== id);
        }

        public async Task<IEnumerable<RoomEntity>> GetRoomsByCityAsync(string city, int capacity)
        {
            return await _hotelDbContext.Rooms
                   .Include(r=>r.Hotel)
                   .Where(r=> r.IsEnabled && 
                          r.Capacity== capacity &&
                          r.Hotel.IsEnabled &&
                          r.Hotel.City ==city).ToListAsync();
        }

        public async Task UpdateAsync(RoomEntity room)
        {
            _hotelDbContext.Rooms.Update(room);
            await _hotelDbContext.SaveChangesAsync();

            
        }
    }
}
