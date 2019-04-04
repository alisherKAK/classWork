namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int PricePerDay { get; set; }
        public int HotelId { get; set; }
    }
}
