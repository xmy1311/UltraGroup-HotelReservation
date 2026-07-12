using HotelService.Domain.Entities;
using HotelService.Domain.Interfaces;
using HotelService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace HotelService.Infrastructure.Repositories
{
    public class HotelRepository(HotelDbContext context) : IHotelRespository
    {
        private readonly HotelDbContext _context = context;

        public async Task CreateHotelAsync(HotelEntity hotel)
        {
           await _context.Hotels.AddAsync(hotel);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteHoltelAsync(Guid id)
        {
            var hotel = _context.Hotels.Find(id);

            if (hotel == null)
                return;

            hotel.Disable();

            _context.Hotels.Update(hotel);

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<HotelEntity>> GetHotelsAllAsync(string? name= null,
                                                          string? city= null,
                                                          bool? enable= null)
        {

            IQueryable<HotelEntity> query = _context.Hotels;
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(h => h.Name.Contains(name));

            if(!string.IsNullOrEmpty(city))
                query= query.Where(h => h.City.Contains(city));

            if(enable.HasValue)
                query=query.Where(h => h.IsEnabled == enable.Value);

            return await query.ToListAsync();

        }

        public Task<HotelEntity?> GetHotelByIdAsync(Guid id)
        {
            return _context.Hotels.FirstOrDefaultAsync(h=>h.Id ==id);
        }

        public async Task UpdateHotelAsync(HotelEntity hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
