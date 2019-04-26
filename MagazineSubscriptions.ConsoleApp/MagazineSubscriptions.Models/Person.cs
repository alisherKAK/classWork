using MagazineSubscriptions.AbstractModels;

namespace MagazineSubscriptions.Models
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
