using MagazineSubscriptions.AbstractModels;
namespace MagazineSubscriptions.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Person Person { get; set; }
    }
}
