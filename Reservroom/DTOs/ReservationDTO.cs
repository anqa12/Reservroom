using System.ComponentModel.DataAnnotations;

namespace Reservroom.DTOs
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }

        public int FloorNum { get; set; }
        public int RoomNum { get; set; }

        public string Username { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
