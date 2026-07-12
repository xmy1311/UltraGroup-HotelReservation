using UltraGroup.Common.Enums;

namespace Reservation.Domain.Entities
{
    public class GuestEntity
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public DocumentType DocumentType { get; set; }

        public string DocumentNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public ReservationEntity Reservation { get; set; } = default!;

        private GuestEntity()
        {
        }

        public GuestEntity(string firstName,
                             string lastName,
                             DateTime birthDate, 
                             Gender gender,
                             DocumentType documentType,
                             string documentNumber,
                             string email,
                             string phoneNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            this.LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            DocumentType= documentType;
            DocumentNumber= documentNumber;
            Email=email;
            PhoneNumber = phoneNumber;  


        }


    }
}
