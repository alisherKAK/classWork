using System;

namespace Hotel.Models
{
    public class BookingBook
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Paid { get; set; } 
    }
}
