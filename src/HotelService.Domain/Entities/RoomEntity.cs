using System;
using System.Collections.Generic;
using System.Text;
using UltraGroup.Common.Enums;

namespace HotelService.Domain.Entities
{
    public class RoomEntity
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }

        public HotelEntity? Hotel { get; set; } = default;
        public string Number { get; set; }= string .Empty;
        public RoomType Type { get; set; }

        public decimal Price { get; set; }

        public decimal Taxes { get; set; }

        public string Location { get; set; } = string.Empty;

        public bool IsEnabled { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Capacity { get; set; }

       

        private RoomEntity()
        {
        }

        public RoomEntity(Guid hotelId, 
                    string number, 
                    RoomType type, 
                    decimal price,
                    decimal taxes, 
                    string location,
                    int capacity)
        {
            Id = Guid.NewGuid();
            HotelId = hotelId;
            Number = number;
            Type = type;
            Price = price;
            Taxes = taxes;
            Location = location;
            Capacity = capacity;
            IsEnabled = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string number, 
                           RoomType type, 
                           decimal price, 
                           decimal taxes, 
                           string location,
                           int capacity)
        {
            Number = number;
            Type = type;
            Price = price;
            Taxes = taxes;
            Location = location;
            Capacity = capacity;
        }

        public void Disable()
        {
            if (!IsEnabled)
                return;
            IsEnabled = false;
        }

        public void Enable()
        {
            if (IsEnabled)
                return;
            IsEnabled = true;
        }
    }


}
