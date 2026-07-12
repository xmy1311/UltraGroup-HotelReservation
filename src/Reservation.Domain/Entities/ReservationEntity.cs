using UltraGroup.Common.Enums;


namespace Reservation.Domain.Entities
{
    public class ReservationEntity
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public  Guid HotelId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
       public int NumberOfGuests { get; set; }
        public ReservationStatus Status { get; set; }

        public string  EmergencyContactName { get; set; } = string.Empty;

        public string EmergencyContactPhone { get; set; }=string.Empty;
        public ICollection<GuestEntity> Guests { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        private ReservationEntity()
        {
        }
        public ReservationEntity(Guid roomId, 
                                  Guid hotelId,
                                  DateTime checkIn,
                                  DateTime checkOut, 
                                  int numberOfGuests, 
                                  string emergencyContactName,
                                  string emergencyContactPhone)
        {
            Id = Guid.NewGuid();
            RoomId = roomId;
            HotelId = hotelId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            NumberOfGuests = numberOfGuests;
            EmergencyContactName = emergencyContactName;
            EmergencyContactPhone = emergencyContactPhone;
            Status = ReservationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }
        public void Update(DateTime checkIng, DateTime checkOut, int numberOfGuests)
        {
            CheckIn = checkIng;
            CheckOut = checkOut;
            NumberOfGuests = numberOfGuests;
            
        }

        public void AddGuest(GuestEntity guest)
        {
            Guests.Add(guest);
        }

        public void Cancel()
        {
            if(Status == ReservationStatus.Cancelled)
            {
                throw new InvalidOperationException("The reservation is already cancelled.");
            }
            Status = ReservationStatus.Cancelled;
        }

        public void Confirm()
        {   
            if(Status != ReservationStatus.Pending)
            {
                throw new InvalidOperationException("Cannot confirm a cancelled reservation.");
            }
            Status = ReservationStatus.Confirmed;
        }

    }
}
