using HomeWork29_04_19.AbstractModels;
using System;

namespace HomeWork29_04_19.Models
{
    public class Ticket : Entity
    {
        public string TicketNumber { get; set; }
        public SeatForTicket SeatForTicket { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public City DepartureCity { get; set; }
        public City CityOfArrival { get; set; }
        public double Price { get; set; }
        public bool IsBuyed { get; set; }
    }
}
