using HomeWork05_05_19.AbstractModels;

namespace HomeWork05_05_19.Models
{
    public class CityPhoneNumber : Entity
    {
        public string Number { get; set; }
        public string Username { get; set; }
        public City City { get; set; }
    }
}
