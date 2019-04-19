using HomeWork29_04_19.AbstractModels;

namespace HomeWork29_04_19.Models
{
    public class SeatForTicket : Entity
    {
        public Train Train { get; set; }
        public RailwayCarriage RailwayCarriage { get; set; }
        public Stateroom Stateroom { get; set; }
        public Spot Spot { get; set; }
        public bool IsEngaged { get; set; }
    }
}
