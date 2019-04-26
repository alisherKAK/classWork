using MagazineSubscriptions.AbstractModels;

namespace MagazineSubscriptions.Models
{
    public class Subscription : Entity
    {
        public double Price { get; set; }
        public int SubscriptionsTimeInMonth { get; set; }
    }
}
