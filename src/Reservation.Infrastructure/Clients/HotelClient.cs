using Reservation.App.DTOs;
using Reservation.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using UltraGroup.Common.Responses;

namespace Reservation.Infrastructure.Clients
{
    public class HotelClient(HttpClient httpClient) : IHotelClient
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task<IEnumerable<AvailableRoomDto>> GetAvailableRoomsAsync(string city, int capacity)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<AvailableRoomDto>>>(
                $"api/room/available?city={city}&capacity={capacity}");

            return response?.Data ?? [];
        }
    }
}
