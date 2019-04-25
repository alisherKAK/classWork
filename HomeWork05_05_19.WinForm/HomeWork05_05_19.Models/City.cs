using HomeWork05_05_19.AbstractModels;
using System.Collections.Generic;

namespace HomeWork05_05_19.Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public string CityPhoneCode { get; set; }
        ICollection<CityPhoneNumber> CityPhoneNumbers { get; set; }
    }
}
