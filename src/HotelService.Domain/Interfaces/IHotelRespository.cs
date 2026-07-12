using HotelService.Domain.Entities;


namespace HotelService.Domain.Interfaces
{
    public interface IHotelRespository
    {
        Task CreateHotelAsync(HotelEntity hotel);
        Task<HotelEntity?> GetHotelByIdAsync(Guid id);

        Task<IEnumerable<HotelEntity>> GetHotelsAllAsync(string? name = null, string? city = null, bool? enabled = null);
  
        Task UpdateHotelAsync(HotelEntity hotel);

        Task DeleteHoltelAsync(Guid id);
    }
}
