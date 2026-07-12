using UltraGroup.Common.Enums;


namespace HotelService.App.DTOs
{
    public class RoomResponseDto
    {
        public Guid  Id { get; set; }

        public Guid HotelId { get; set; }

        public string Number { get; set; } = string.Empty;

        public RoomType Type { get; set; }

        public decimal Price { get; set; }

        public decimal Taxes { get; set; }

        public string Location { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public bool IsEnabled { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
