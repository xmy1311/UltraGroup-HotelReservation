using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.Domain.Entities
{
    public class HotelEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<RoomEntity> Rooms { get; set; } = [];

        private HotelEntity()
        {
        }

        public HotelEntity(string name, string city, string address, string description)
        {

            Id = Guid.NewGuid();
            Name = name;
            City = city;
            Address = address;
            Description = description;
            IsEnabled = true;
            CreatedAt = DateTime.UtcNow;

        }

        public void Update(string name, string city, string address, string description)
        {
            Name = name;
            City = city;
            Address = address;
            Description = description;
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
